using UnityEngine;
using UnityEditor;
namespace EditorExtensions
{
    [CustomEditor(typeof(MechMeshEditorControl))]
    public class MaterialApplication : Editor
    {
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            var mechMesh = (MechMeshEditorControl)target;

            if (GUILayout.Button("Swap Materials"))
            {
                mechMesh.ChangeMat();
                Debug.Log("Swapping mats");
            }

            if (GUILayout.Button("Clear children"))
            {
                mechMesh.ClearChildren();
            }
        }
    }
}
