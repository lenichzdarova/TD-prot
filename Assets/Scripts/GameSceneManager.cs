

using UnityEngine.SceneManagement;

public static class GameSceneManager //shitty class need rework
{        
    private const int MAIN_MENU_SCENE_INDEX = 0;

    public static void LoadNextScene(PlayerPersistentData playerData)
    {
        playerData.LastPlayedSceneIndex++;
        DataManager.SaveData(playerData);

        SceneManager.LoadScene(playerData.LastPlayedSceneIndex);
    }

    public static void LoadLastGameScene(PlayerPersistentData playerData)
    {        
        SceneManager.LoadScene(playerData.LastPlayedSceneIndex);
    }

    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_INDEX);
    }
}