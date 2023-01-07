using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    public Building GetBuilding(Building prefab)
    {
        Building building = Instantiate(prefab);        
        return building;
    }

    public void Recycle(Building building)
    {
        Destroy(building.gameObject);
    }    
}
