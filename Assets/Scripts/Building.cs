
using System;
using UnityEngine;

public class Building : MonoBehaviour
{
    public event Action<Tower[]> OnBuild;
    
    [SerializeField] Tower[] prefabs;


    private void OnMouseDown()
    {
        OnBuild?.Invoke(GetUpgrades());
    }

    public Tower[] GetUpgrades()
    {
        return prefabs;
    }

    public void Build(int prefabIndex)
    {

    }

    public void Sell()
    {

    }

}
