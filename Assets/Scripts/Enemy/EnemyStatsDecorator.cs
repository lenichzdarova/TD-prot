
public abstract class EnemyStatsDecorator : IStatsProvider<EnemyStats>
{
    protected readonly IStatsProvider<EnemyStats> _statsProvider;

    public EnemyStatsDecorator (IStatsProvider<EnemyStats> statsProvider)
    {
        _statsProvider = statsProvider;
    }

    public abstract EnemyStats GetStats();
}