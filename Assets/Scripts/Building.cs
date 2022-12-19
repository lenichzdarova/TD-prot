
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    public event Action<Building[], int, bool> OnBuildingClicked;    
    
    [SerializeField] Building[] upgrades;
    [SerializeField] Sprite icon;
    [SerializeField] int cost;
    [SerializeField] bool canSell;    
    
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            OnBuildingClicked?.Invoke(upgrades,cost,canSell);
        }        
    }

    public Building[] GetUpgrades()
    {
        return upgrades;
    }  
    
    public Sprite GetIcon() { return icon; }
    public int GetCost() { return cost; }
    public bool CanSell() { return canSell;}
}
