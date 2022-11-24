
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    public event Action<Building> OnBuild;    
    
    [SerializeField] Building[] upgrades;
    [SerializeField] Sprite icon;
    [SerializeField] int cost;
    [SerializeField] bool canSell;

    
    
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            OnBuild?.Invoke(this);
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
