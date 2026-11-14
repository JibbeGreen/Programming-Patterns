using UnityEngine;

namespace Patterns
{
    [CreateAssetMenu(menuName = "SOAP/Variables/String")]
    public class StringVariable : ScriptableVariable<string>
    {
        // null and "" mean the same thing for settings (e.g. "no device chosen").
        protected override bool AreEqual(string a, string b) => string.Equals(a ?? string.Empty, b ?? string.Empty);
    }
}
