using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildUIProvider 
{
    public event Action<int> buildingIndexSelected;
    public event Action sellTower;
    public void OnBuildActivation(Building[] buildings, int sellGoldAmount, bool canSell);
}
