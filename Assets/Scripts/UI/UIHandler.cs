using UnityEngine;
using System.Collections.Generic;
using System;

public class UIHandler : MonoBehaviour
{
    private BuildUI buildUI;
    private GoldUI goldUI;
    [SerializeField] private HealthUI healthUI;
    private StartMenuUI startMenuUI;    

    public void Init(IPlayerEventsProvider playerEventsProvider, int playerHealth, int playerGold)
    {  
        //startMenuUI.Show();
        //goldUI.Hide();
        healthUI.Init(playerEventsProvider, playerHealth);
        //buildUI.Hide();
    }

}