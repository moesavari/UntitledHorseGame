using UnityEngine;

public class InfoBoardMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _horseTypeCanvas;
    [SerializeField] private GameObject _horseBreedCanvas;
    [SerializeField] private GameObject _eventCanvas;
    [SerializeField] private GameObject _attireCanvas;

    private GameObject _currentCanvas;

    private void OnEnable()
    {
        StartWithMainCanvas();
    }

    public void OnHorseTypeButtonPressed()
    {
        SwapCurrentCanvas(_horseTypeCanvas);
    }

    public void OnHorseBreedButtonPressed()
    {
        SwapCurrentCanvas(_horseBreedCanvas);
    }

    public void OnEventButtonPressed()
    {
        SwapCurrentCanvas(_eventCanvas);
    }

    public void OnAttireButtonPressed()
    {
        SwapCurrentCanvas(_attireCanvas);
    }

    public void ReturnToMainCanvas()
    {
        _currentCanvas.SetActive(false);
        _mainCanvas.SetActive(true);

        _currentCanvas = _mainCanvas;
    }

    private void SwapCurrentCanvas(GameObject newCanvas)
    {
        _currentCanvas.SetActive(false);
        newCanvas.SetActive(true);

        _currentCanvas = newCanvas;
    }

    private void StartWithMainCanvas()
    {
        _mainCanvas.SetActive(true);

        _horseTypeCanvas.SetActive(false);
        _horseBreedCanvas.SetActive(false);
        _eventCanvas.SetActive(false);
        _attireCanvas.SetActive(false);

        _currentCanvas = _mainCanvas;
    }
}
