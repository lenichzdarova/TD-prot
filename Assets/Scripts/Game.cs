using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameBoard gameBoard;
    [SerializeField] UIHandler uiHandler;    
    private CameraHandler cameraHandler;
    private Player player;
    private int fps=60;   
    private int playerStartHealth = 100;
    private int playerStartGold = 100; 

    private void Awake()
    {
        Application.targetFrameRate = fps;        
        player = new Player(playerStartHealth,playerStartGold);
        uiHandler.Initialize(player,player);
        cameraHandler = new CameraHandler(Camera.main);
        gameBoard.Initialize(player,uiHandler);
    }   
}
