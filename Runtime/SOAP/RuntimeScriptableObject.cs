using System.Collections.Generic;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

namespace Patterns
{
    [AutoStaticsCleanup]
    public abstract partial class RuntimeScriptableObject : ScriptableObject
    {
        static readonly List<RuntimeScriptableObject> Instances = new();

        void OnEnable() => Instances.Add(this);
        void OnDisable() => Instances.Remove(this);

        protected abstract void OnReset();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void ResetAllInstances()
        {
            foreach (var instance in Instances)
            {
                instance.OnReset();
            }
        }
    }
}
