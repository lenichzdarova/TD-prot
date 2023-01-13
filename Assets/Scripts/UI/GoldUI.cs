using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldValueTextHolder;
    private IPlayerGoldProvider _playerGoldProvider;

    public void Initialize(IPlayerGoldProvider iPlayerGoldProvider)
    {
        Show();
        _playerGoldProvider = iPlayerGoldProvider;
        SetGoldText(iPlayerGoldProvider.Gold);
        iPlayerGoldProvider.PlayerGoldChanged += SetGoldText;        
    }

    private void SetGoldText(int value)
    {
        _goldValueTextHolder.text = value.ToString();
    }

    public void Hide()
    {
        _playerGoldProvider.PlayerGoldChanged -= SetGoldText;
        gameObject.SetActive(false);        
    }

    public void Show()
    {
        gameObject.SetActive(true); 
    }
}

