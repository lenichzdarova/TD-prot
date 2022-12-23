using System;

public interface IPlayerGoldProvider
{
    public event Action<int> PlayerGoldChange;

    public int Gold { get; set; }

    public void AddGold(int value);
}