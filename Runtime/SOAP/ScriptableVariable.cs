using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Patterns
{
    public abstract class ScriptableVariable<T> : RuntimeScriptableObject
    {
        [SerializeField] T initialValue;
        [SerializeField] T value;

        public event UnityAction<T> OnValueChanged = delegate { };

        public T Value
        {
            get => value;
            set
            {
                if (AreEqual(this.value, value)) return;
                this.value = value;
                OnValueChanged.Invoke(value);
            }
        }

        /// <summary>Override when plain equality isn't right (floats).</summary>
        protected virtual bool AreEqual(T a, T b) => EqualityComparer<T>.Default.Equals(a, b);
        protected override void OnReset() => value = initialValue;
    }
}
