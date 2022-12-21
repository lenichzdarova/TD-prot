using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildUIProvider 
{
    public event Action<int> buildingIndexSelected;
    public BuildUI GetBuildUI();
    public void InitializeBuildUI(Building[] buildings, int towerCost, bool canSell);
}
