using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Events;

public class ScreenView : MonoBehaviour
{
    private Vector3 _originalPosition;

    protected virtual void Start()
    {
        Debug.Log($"SV: Started in parent ScreenView on object {gameObject.name}", gameObject);
        _originalPosition = transform.GetComponent<RectTransform>().anchoredPosition;
    }

    [ButtonInvoke(nameof(SetOpacity), 0.5f, ButtonInvoke.DisplayIn.PlayAndEditModes, "sv: Make half transparent")] public bool makeTransparentButton;  
    [ButtonInvoke(nameof(SetOpacity), 1.0f, ButtonInvoke.DisplayIn.PlayAndEditModes, "sv: Make full opaque")] public bool makeOpaqueButton;  

    public void SetOpacity(float newOpacity)
    {
        Debug.Log($"SV: Setting opacity to {newOpacity}", gameObject);
        GetComponent<CanvasRenderer>().SetAlpha(newOpacity);
    }
    public void ResetToOriginalPosition()
    {
        transform.GetComponent<RectTransform>().anchoredPosition = _originalPosition;
    }
}
