using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor;

namespace Patterns.Editor
{
    [CustomPropertyDrawer(typeof(IntVariable))]
    public class IntVariableDrawer : PropertyDrawer 
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property) 
        {
            var container = new VisualElement();

            var objectField = new ObjectField(property.displayName) 
            {
                objectType = typeof(IntVariable)
            };
            objectField.BindProperty(property);

            var valueLabel = new Label();
            valueLabel.style.paddingLeft = 20;

            container.Add(objectField);
            container.Add(valueLabel);

            objectField.RegisterValueChangedCallback(
                evt => 
                {
                    var variable = evt.newValue as IntVariable;
                    if (variable != null) 
                    {
                        valueLabel.text = $"Current Value: {variable. Value}";
                        variable. OnValueChanged += newValue => valueLabel.text = $"Current Value: {newValue}";
                    } 
                    else 
                    {
                        valueLabel.text = string.Empty;
                    }
                }
            );

            var currentVariable = property.objectReferenceValue as IntVariable;
            if (currentVariable != null) 
            {
                valueLabel.text = $"Current Value: {currentVariable. Value}";
                currentVariable. OnValueChanged += newValue => valueLabel. text = $"Current Value: {newValue}";
            }

            return container;
        }
    }
}
