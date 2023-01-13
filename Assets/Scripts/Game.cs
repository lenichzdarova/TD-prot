using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameBoard _gameBoard;
    [SerializeField] UIHandler _uiHandler;    
    private CameraHandler _cameraHandler;
    private Player _player;
    private int _fps = 60;   
    private int _playerStartHealth = 100;
    private int _playerStartGold = 100; 

    private void Awake()
    {
        Application.targetFrameRate = _fps;        
        _player = new Player(_playerStartHealth,_playerStartGold);
        _uiHandler.Initialize(_player,_player.GetHealth());
        _cameraHandler = new CameraHandler(Camera.main);
        _gameBoard.Initialize(_player.GetHealth(),_player,_uiHandler);
    }   
}
