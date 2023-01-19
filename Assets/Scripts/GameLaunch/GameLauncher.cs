
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    [SerializeField]
    private MainMenu _mainMenu;
    private DataManager _dataManager;
    private GameSceneManager _gameSceneManager;

    private void Awake()
    {
        _dataManager = new DataManager();
        var playerData = _dataManager.LoadData();        
        _mainMenu.Initialize(playerData);
        _gameSceneManager = new GameSceneManager();
        _mainMenu.ContinueClick += OnCountinueClick;
        _mainMenu.NewGameClick += OnNewGameClick;
        _mainMenu.QuitClick += OnQuitClick;
    }

    private void OnCountinueClick()
    {
        _gameSceneManager.LoadLastGameScene();
    }

    private void OnNewGameClick()
    {
        var playerDefaultData = new PlayerPersistentData();
        _dataManager.SaveData(playerDefaultData);
        _gameSceneManager.LoadNextScene();
    }
    private void OnQuitClick()
    {
        Application.Quit();
    }
}
