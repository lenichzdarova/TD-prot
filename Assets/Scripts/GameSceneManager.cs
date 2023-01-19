

using UnityEngine.SceneManagement;

public class GameSceneManager //shitty class need rework
{        
    private const int MAIN_MENU_SCENE_INDEX = 0;
    
    public void LoadNextScene()
    {
        var dataManager = new DataManager();
        var playerData = dataManager.LoadData();
        ++playerData.SceneIndex;       
        dataManager.SaveData(playerData);
        SceneManager.LoadScene(playerData.SceneIndex);
    }

    public void LoadLastGameScene()
    {
        var dataManager = new DataManager();
        var playerData = dataManager.LoadData();
        SceneManager.LoadScene(playerData.SceneIndex);
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_INDEX);
    }
}