using UnityEngine;
using UnityEngine.Events;

namespace Patterns
{
    [CreateAssetMenu(menuName = "Variables/Bool Variable")]
    public class BoolVariable : RuntimeScriptableObject 
    {
        [SerializeField] bool initialValue;
        [SerializeField] bool value;

        public event UnityAction<bool> OnValueChanged = delegate { };

        public bool Value 
        {
            get => value;
            set 
            {
                if (this.value == value) return;
                this.value = value;
                OnValueChanged.Invoke(value);
            }
        }

        protected override void OnReset() => value = initialValue;
    }
}
