using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    public class MechMeshEditorControl : MonoBehaviour
    {
        public GameObject meshParent;
        public Material newMat;
        public List<Transform> allChildren;
        public void ChangeMat()
        {
            if (allChildren.Count <= 0)
            {
                RecursiveFindChild(meshParent.transform);
            }

            foreach (var child in allChildren)
            {
                child.GetComponent<SkinnedMeshRenderer>().material = newMat;
            }
        }

        public void ClearChildren()
        {
            allChildren.Clear();
        }
        void RecursiveFindChild(Transform parent)
        {
            foreach (Transform child in parent)
            {
                Debug.Log(child.name + " checked");
                if (child.GetComponent<SkinnedMeshRenderer>())
                {
                    allChildren.Add(child);
                } 
                RecursiveFindChild(child);
            }
        }
    }
}
