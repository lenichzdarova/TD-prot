
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    [SerializeField]
    private MainMenu _mainMenu;
    private PlayerPersistentData _persistentData;

    private void Awake()
    {
        var dataManager = new DataManager();
        _persistentData = dataManager.LoadData();
        _mainMenu.Initialize(_persistentData);
    }    
}
