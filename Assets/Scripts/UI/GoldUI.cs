using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour, IUIElement
{
    [SerializeField] private TextMeshProUGUI goldValueHolder;

    public void Init(IPlayerEventsProvider playerEventsProvider, int playerGold)
    {
        SetGoldValue(playerGold);
        playerEventsProvider.playerGoldChange += SetGoldValue;        
    }

    private void SetGoldValue(int value)
    {
        goldValueHolder.text = value.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(false);
    }
}

