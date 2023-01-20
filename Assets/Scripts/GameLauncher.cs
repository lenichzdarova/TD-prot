
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    [SerializeField]
    private MainMenu _mainMenu;    

    private void Awake()
    {        
        var playerData = DataManager.LoadData();        
        _mainMenu.Initialize(playerData);        
        _mainMenu.ContinueClick += OnCountinueClick;
        _mainMenu.NewGameClick += OnNewGameClick;
        _mainMenu.QuitClick += OnQuitClick;
    }

    private void OnCountinueClick()
    {
        var playerData = DataManager.LoadData();
        GameSceneManager.LoadLastGameScene(playerData);
    }

    private void OnNewGameClick()
    {
        var playerDefaultData = new PlayerPersistentData();       
        DataManager.SaveData(playerDefaultData);
        GameSceneManager.LoadNextScene(playerDefaultData);
    }
    private void OnQuitClick()
    {
        Application.Quit();
    }
}
