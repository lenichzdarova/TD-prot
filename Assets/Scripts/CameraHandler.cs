using UnityEngine;

public class CameraHandler
{
    private Camera camera;   

    public CameraHandler (Camera camera)
    {
        this.camera = camera;
        camera.aspect = 1.77f;
    }

    public Vector3 GetScreenPoint(Vector3 worldPoint)
    {
        return camera.WorldToScreenPoint(worldPoint);
    }
}