using UnityEngine;

namespace Patterns
{
    [CreateAssetMenu(menuName = "SOAP/Variables/Float")]
    public class FloatVariable : ScriptableVariable<float>
    {
        protected override bool AreEqual(float a, float b) => Mathf.Approximately(a, b);
    }

}
