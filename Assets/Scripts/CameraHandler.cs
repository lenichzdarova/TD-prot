using UnityEngine;

public class CameraHandler
{
    private Camera _camera;   

    public CameraHandler (Camera camera)
    {
        _camera = camera;
        camera.aspect = 1.77f;
    }

    public Vector3 GetScreenPoint(Vector3 worldPoint)
    {
        return _camera.WorldToScreenPoint(worldPoint);
    }
}