using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] Transform anchor;
    private KeyCode leftRotation = KeyCode.Q;
    private KeyCode righttRotation = KeyCode.E;

    private const float ROTATION_DELTA = 45f;
    private const float ROTATION_SPEED = 2f;
    private void Awake()
    {
        //transform.LookAt(anchor);
    }

    private void Update()
    {
        if (Input.GetKeyDown(leftRotation))
        {
            CamRotate(ROTATION_DELTA);
        }
        else if (Input.GetKeyDown(righttRotation))
        {
            CamRotate(-ROTATION_DELTA);
        }
    }

    private void CamRotate(float rotationValue)
    {
        Vector3 rotationTarget = new Vector3(anchor.eulerAngles.x, anchor.eulerAngles.y + rotationValue, anchor.eulerAngles.z);
        Vector3.Lerp(anchor.eulerAngles, rotationTarget, ROTATION_SPEED);
        anchor.Rotate(Vector3.up, rotationValue);        
    }

}


