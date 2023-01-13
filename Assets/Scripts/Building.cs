
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    public event Action<Building> BuildingClicked;    
    
    [SerializeField] Building[] _upgrades;
    [SerializeField] Sprite _icon;
    [SerializeField] int _cost;
    [SerializeField] bool _canSell;    
    
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            BuildingClicked?.Invoke(this);
        }        
    }

    public Building[] GetUpgrades()
    {
        return _upgrades;
    }  
    
    public Sprite GetIcon() { return _icon; }
    public int GetCost() { return _cost; }
    public bool CanSell() { return _canSell;}
}
