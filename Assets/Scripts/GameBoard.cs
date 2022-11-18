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
    private Building currentSelected;


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
        buildUI.OnBuild += BuildTower;
        buildUI.OnSell += SellTower;

    }    

    private void OpenBuildUI(Building building)
    {
        currentSelected= building;
        bool canSell = currentSelected.CanSell();
        Building[] upgrades = building.GetUpgrades();
        buildUI.gameObject.SetActive(true);
        buildUI.Initialize(canSell);        
        for (int i = 0; i < upgrades.Length; i++)
        {
            Building upgrade = upgrades[i];
            Sprite buttonIcon = upgrade.GetIcon();
            int cost = upgrade.GetCost();           
            bool enoughGold = controller.GetGold()>=upgrade.GetCost()?true:false;
            buildUI.ActivateButton(i, buttonIcon, cost,enoughGold);            
        }
    }

    private void BuildTower(int index)
    {        
        Building building = currentSelected.GetUpgrades()[index];
        Vector3 position = currentSelected.transform.position;
        Quaternion rotation = currentSelected.transform.rotation;
        Building instance = Instantiate(building,position,rotation);
        controller.ChangeGold(-instance.GetCost());
        instance.OnBuild += OpenBuildUI;
    }
    private void SellTower()
    {

    }
}
