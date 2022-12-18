
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameBoard gameBoard;    
    [SerializeField] Camera cam;
    private Player player;
    private int fps=60;

    private void Awake()
    {
        Application.targetFrameRate = fps;
        cam.aspect = 1.77f;

        player = new Player();
        gameBoard.Initialize(player);  
        
    }       

    public Camera GetCam()
    {
        return cam;
    }
}
