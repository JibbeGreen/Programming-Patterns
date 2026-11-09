#if UNITY_EDITOR
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

            IntVariable watched = null;
            void OnChanged(int newValue) => valueLabel.text = $"Current Value: {newValue}";

            // Keeps exactly one subscription, on the currently assigned variable.
            void Watch(IntVariable variable)
            {
                if (watched != null) watched.OnValueChanged -= OnChanged;
                watched = variable;

                if (watched != null)
                {
                    valueLabel.text = $"Current Value: {watched.Value}";
                    watched.OnValueChanged += OnChanged;
                }
                else
                {
                    valueLabel.text = string.Empty;
                }
            }

            objectField.RegisterValueChangedCallback(evt => Watch(evt.newValue as IntVariable));
            // Unsubscribe when the inspector goes away so handlers don't pile up on the asset.
            container.RegisterCallback<DetachFromPanelEvent>(_ => Watch(null));

            Watch(property.objectReferenceValue as IntVariable);

            return container;
        }
    }
}
#endif
