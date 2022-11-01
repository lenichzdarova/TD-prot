using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] GameBoard gameBoard;    

    private int fps=60;

    private void Awake()
    {
        Application.targetFrameRate = fps;
        
    }
     

}
