using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameBoard : MonoBehaviour
{   
    [SerializeField] Spawner[] spawners;
    [SerializeField] Building[] buildings;
    [SerializeField] BuildUI buildUI;
    private Controller controller;


    public void Initialize(Controller controller)
    {
        this.controller = controller;
        foreach(Spawner spawner in spawners) 
        {
            spawner.Initialize();
        }       
        foreach(Building building in buildings)
        {
            building.OnBuild += OpenBuildUI;
        }        
    }

    private void OpenBuildUI(Tower[] towers)
    {
        buildUI.gameObject.SetActive(true);
        buildUI.ActivateButtons(towers.Length);
        Sprite[] icons= new Sprite[towers.Length];
        for(int i = 0; i < icons.Length; i++)
        {
            icons[i] = towers[i].GetIcon();
        }
        buildUI.SetButtonIcons(icons);
    }
}
