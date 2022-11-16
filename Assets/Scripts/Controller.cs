using Newtonsoft.Json.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] GameBoard gameBoard;   
    [SerializeField] TextMeshProUGUI goldUI;
    [SerializeField] TextMeshProUGUI healthUI;

    public event Action<int> OnGoldChange;
    public event Action<int> OnHealthChange;

    private int gold;
    private int health;    

    private int fps=60;

    private void Awake()
    {
        Application.targetFrameRate = fps;
        gameBoard.Initialize(this);

        ChangeHealth(100);
        ChangeGold(100);
        
    }

    public  void ChangeHealth(int value)
    {
        health += value;
        healthUI.text = health.ToString();        
        OnHealthChange?.Invoke(health);
    }

    public void ChangeGold(int value)
    {
        gold += value;
        goldUI.text = gold.ToString();
        OnGoldChange?.Invoke(gold);
    }    
}
