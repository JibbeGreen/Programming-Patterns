using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
    // Intentionally NOT [AutoStaticsCleanup]: Instances is filled by OnEnable when the assets load
    // (in edit mode) and those assets survive entering Play Mode, so clearing the list there would
    // mean nothing gets reset when domain reload is disabled.
    public abstract partial class RuntimeScriptableObject : ScriptableObject
    {
        static readonly List<RuntimeScriptableObject> Instances = new();

        void OnEnable()
        {
            if (!Instances.Contains(this)) Instances.Add(this);
#if !UNITY_EDITOR
            // In a player, assets referenced by the first scene are loaded after BeforeSceneLoad,
            // so ResetAllInstances would miss them. Reset on load instead.
            OnReset();
#endif
        }

        void OnDisable() => Instances.Remove(this);

        protected abstract void OnReset();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void ResetAllInstances()
        {
            foreach (var instance in Instances.ToArray())
            {
                if (instance != null) instance.OnReset();
            }
        }
    }
}
