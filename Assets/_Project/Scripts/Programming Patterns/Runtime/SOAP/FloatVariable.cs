using UnityEngine;
using UnityEngine.Events;

namespace Patterns
{
    [CreateAssetMenu(menuName = "Variables/Float Variable")]
    public class FloatVariable : RuntimeScriptableObject 
    {
        [SerializeField] float initialValue;
        [SerializeField] float value;

        public event UnityAction<float> OnValueChanged = delegate { };

        public float Value 
        {
            get => value;
            set 
            {
                if (Mathf.Approximately(this.value, value)) return;
                this.value = value;
                OnValueChanged.Invoke(value);
            }
        }

        protected override void OnReset() => value = initialValue;
    }
}
