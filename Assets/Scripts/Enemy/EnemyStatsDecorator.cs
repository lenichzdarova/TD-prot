
public abstract class EnemyStatsDecorator : IEnemyStatsProvider
{
    protected readonly IEnemyStatsProvider _statsProvider;

    public EnemyStatsDecorator (IEnemyStatsProvider statsProvider)
    {
        _statsProvider = statsProvider;
    }

    public abstract EnemyStats GetStats();
}