using UnityEngine;

public class CanvasSwap : MonoSingleton<CanvasSwap>
{
    [Header("Canvas Objects")]
    [SerializeField] private GameObject _mainMenuCanvas;
    [SerializeField] private GameObject _playMenuCanvas;
    [SerializeField] private GameObject _stableMenuCanvas;
    [SerializeField] private GameObject _infoBoardCanvas;

    [Header("Camera Positions")]
    [SerializeField] private Transform _mainMenuCameraPosition;
    [SerializeField] private Transform _stableMenuCameraPosition;

    private GameObject _currentCanvas;

    //Instanced variables
    private CameraController _cameraController;

    private void Start()
    {
        _cameraController = CameraController.Instance;

        StartWithMainMenu();
    }

    public void SwapToMainMenu()
    {
        _cameraController.DoCameraMove(_mainMenuCameraPosition);
        SwapCurrentCanvas(_mainMenuCanvas);
    }

    public void SwapToPlayMenu()
    {
        SwapCurrentCanvas(_playMenuCanvas);
    }

    public void SwapToStableMenu()
    {
        _cameraController.DoCameraMove(_stableMenuCameraPosition);
        SwapCurrentCanvas(_stableMenuCanvas);
    }

    public void SwapToInfoBoard()
    {
        SwapCurrentCanvas(_infoBoardCanvas);
    }

    private void SwapCurrentCanvas(GameObject newCanvas)
    {
        _currentCanvas.SetActive(false);
        newCanvas.SetActive(true);

        _currentCanvas = newCanvas;
    }

    private void StartWithMainMenu()
    {
        _mainMenuCanvas.SetActive(true);
        _currentCanvas = _mainMenuCanvas;

        _playMenuCanvas.SetActive(false);
        _stableMenuCanvas.SetActive(false);
    }
}
