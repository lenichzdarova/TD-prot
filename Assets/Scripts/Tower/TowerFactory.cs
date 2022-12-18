using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    public Tower CreateEnemy(Tower prefab)
    {
        return Instantiate(prefab);
    }

    public void Recycle(Tower tower)
    {
        Destroy(tower.gameObject);
    }    
}
