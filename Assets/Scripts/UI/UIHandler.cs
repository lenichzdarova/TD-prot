using UnityEngine;
using System.Collections.Generic;
using System;

public class UIHandler : MonoBehaviour, IBuildUIProvider
{
    [SerializeField] private BuildUI buildUI;
    [SerializeField] private GoldUI goldUI;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private IngameMenuUI ingameMenuUI;    

    public void Init(IPlayerEventsProvider playerEventsProvider, int playerHealth, int playerGold)
    {
        //ingameMenuUI.Show();
        goldUI.Init(playerEventsProvider, playerGold);
        healthUI.Init(playerEventsProvider, playerHealth);
        //buildUI.Hide(); 
    }

    public void InitializeBuildUI(Building[] buildings, int towerCost, bool canSell)
    {
        buildUI.Initialize( buildings,towerCost, canSell);
    }

}