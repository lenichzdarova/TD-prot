using System;

public interface IPlayerGoldProvider
{
    public event Action<int> PlayerGoldChanged;

    public int Gold { get; set; }

    public void AddGold(int value);

    public void RemoveGold(int value);
}