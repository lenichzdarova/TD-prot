using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private void OnEnable()
    {
        Application.targetFrameRate = 60;
    }
}
