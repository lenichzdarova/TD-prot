using System;
using System.Collections;
using UnityEngine;

public interface IPlayerReady
{
    public event Action ReadyToPlay;
    public void Initialize();
}