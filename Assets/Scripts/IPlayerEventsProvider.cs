using System;

public interface IPlayerEventsProvider
{
    public event Action<int> playerGoldChange;
    public event Action<int> playerHealthChange;
}