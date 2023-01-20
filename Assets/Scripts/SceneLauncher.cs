using UnityEngine;


/// <summary>
/// TODO. 
/// Scene want to have player agree to start;
/// UI script with uihandler.PlayerReady event invocation. Concrete  - tutorial windows, pre-level tower upgrades
/// Because its mono, need Interface. And above scripts inherits from it; 
/// 
/// Think about init methods/ probably most of initializable objects need to share responsibility on init and activation methods.
/// For what? Because some times i need data from objects but dont want it to be active. Thanks captain.
/// 
/// Conrete implementation of upgrades system. Upgarades cost what?
/// </summary>

public class SceneLauncher : MonoBehaviour
{
    [SerializeField] GameBoard _gameBoard;
    [SerializeField] UIHandler _uiHandler;    
    private Player _player;      
    private int _playerStartHealth = 100;
    private int _playerStartGold = 100;   

    private void Awake()
    {               
        _player = new Player(_playerStartHealth,_playerStartGold);
        _uiHandler.Initialize(_player,_player.GetHealth());        
        _uiHandler.PlayerReady += OnPlayerReady;
    }
    
    private void OnPlayerReady()
    {
        _gameBoard.Initialize(_player.GetHealth(), _player, _uiHandler);
    }
}
