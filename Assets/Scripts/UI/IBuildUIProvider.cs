using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildUIProvider 
{
    public void InitializeBuildUI(Building[] buildings, int towerCost, bool canSell);
}
