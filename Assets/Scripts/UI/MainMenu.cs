using UnityEngine;
using System;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public event Action NewGameClick;
    public event Action ContinueClick;
    public event Action QuitClick;

    [SerializeField]
    private Button _continue;
    [SerializeField]
    private Button _newGame;
    [SerializeField]
    private Button _quit;

    public void Initialize(PlayerPersistentData data)
    {
        if (data.LastPlayedSceneIndex > 0)
        {
            _continue.interactable = true;
        }

        _continue.onClick.AddListener(Continue);
        _newGame.onClick.AddListener(NewGame);
        _quit.onClick.AddListener(Quit);
    }

    private void Continue()
    {
        ContinueClick?.Invoke();
    }

    private void NewGame()
    {
        NewGameClick?.Invoke();
    }

    private void Quit()
    {
        QuitClick?.Invoke();
    }
}
