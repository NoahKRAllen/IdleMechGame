using UnityEditor;
using UnityEngine;

public class SceneLabel : MonoBehaviour
{
    void OnDrawGizmos() 
    {
        // get the width and height of this rect transform
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 size = rectTransform.rect.size;
        
        // subtract half of the width and height of this rect traform from the transform position
        Vector2 position = rectTransform.position;
        position.x -= size.x * 0.5f;
        position.y -= size.y * 0.5f;
        
        // draw a rectangle at the transform position and size
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(position, size);
        Handles.Label(position, "TEXT");
    }

}
