using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Instanced variables
    private CanvasSwap _canvasSwap;

    private void Start()
    {
        _canvasSwap = CanvasSwap.Instance;
    }

    public void OnPlayButtonPressed()
    {
        _canvasSwap.SwapToPlayMenu();
    }

    public void OnStableButtonPressed()
    {
        _canvasSwap.SwapToStableMenu();
    }

    public void OnInfoBoardButtonPressed()
    {
        _canvasSwap.SwapToInfoBoard();
    }

    public void OnExitButtonPressed()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
