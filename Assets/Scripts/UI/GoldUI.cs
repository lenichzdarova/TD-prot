using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldValueTextHolder;
    private IPlayerGoldProvider playerGoldProvider;

    public void Initialize(IPlayerGoldProvider iPlayerGoldProvider)
    {
        Show();
        playerGoldProvider = iPlayerGoldProvider;
        SetGoldText(iPlayerGoldProvider.Gold);
        iPlayerGoldProvider.PlayerGoldChange += SetGoldText;        
    }

    private void SetGoldText(int value)
    {
        goldValueTextHolder.text = value.ToString();
    }

    public void Hide()
    {
        playerGoldProvider.PlayerGoldChange-=SetGoldText;
        gameObject.SetActive(false);        
    }

    public void Show()
    {
        gameObject.SetActive(true); 
    }
}

