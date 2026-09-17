using UnityEngine;
using UnityEngine.Events;

namespace Patterns
{
    [CreateAssetMenu(menuName = "Variables/Int Variable")]
    public class IntVariable : RuntimeScriptableObject 
    {
        [SerializeField] int initialValue;
        [SerializeField] int value;

        public event UnityAction<int> OnValueChanged = delegate { };

        public int Value 
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
