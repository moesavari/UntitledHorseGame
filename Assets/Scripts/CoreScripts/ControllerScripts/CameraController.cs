using UnityEngine;
using DG.Tweening;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] private GameObject _mainCameraObject;
    [SerializeField] private float _moveDuration;

    public void DoCameraMove(Transform newPosition)
    {
        _mainCameraObject.transform.DOMove(newPosition.position, _moveDuration);
        _mainCameraObject.transform.DORotate(newPosition.rotation.eulerAngles, _moveDuration);
    }
}
