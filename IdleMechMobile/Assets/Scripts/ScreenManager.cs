using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject currentlyActiveScreen;

    private void Start()
    {
        if (currentlyActiveScreen) return;
        //Need a better way to default to a specific gameobject, but without linking it to the script
        //Could do a GetComponent if I have a component on the default screen that I can go searching for
        currentlyActiveScreen = GameObject.Find("MainGameScreen");
        SwapScreenTo(currentlyActiveScreen);
    }

    public void SwapScreenTo(GameObject screenToSwapTo)
    {
        currentlyActiveScreen.SetActive(false);
        currentlyActiveScreen = screenToSwapTo;
        currentlyActiveScreen.SetActive(true);
    }
}
