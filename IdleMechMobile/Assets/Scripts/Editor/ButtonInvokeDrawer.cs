using UnityEditor;
using UnityEngine;

// Place this in a folder called "Editor" somewhere in your project.
// https://gist.github.com/anastasiadevana/2783a15edf1a969c62186e4c2ec0fa8b

[CustomPropertyDrawer(typeof(ButtonInvoke))]
public class ButtonInvokeDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ButtonInvoke settings = (ButtonInvoke) attribute;
        return DisplayButton(ref settings) ? EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing : 0;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ButtonInvoke settings = (ButtonInvoke) attribute;
    
        if (!DisplayButton(ref settings)) return;
    
        string buttonLabel = (!string.IsNullOrEmpty(settings.customLabel)) ? settings.customLabel : label.text;

        if (property.serializedObject.targetObject is MonoBehaviour mb)
        {
            if (GUI.Button(position, buttonLabel))
            {
                mb.SendMessage(settings.methodName, settings.methodParameter);
            }
        }
    }
    
    private bool DisplayButton(ref ButtonInvoke settings)
    {
        return (settings.displayIn == ButtonInvoke.DisplayIn.PlayAndEditModes) ||
               (settings.displayIn == ButtonInvoke.DisplayIn.EditMode && !Application.isPlaying) ||
               (settings.displayIn == ButtonInvoke.DisplayIn.PlayMode && Application.isPlaying);
    }
}