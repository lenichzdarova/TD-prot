

public class SlowEnemyStats : EnemyStatsDecorator
{
    public SlowEnemyStats(IStatsProvider<EnemyStats> statsProvider) : base(statsProvider)
    {

    }

    public override EnemyStats GetStats()
    {
        var stats = _statsProvider.GetStats();
        stats.Speed *= 0.5f;
        return stats;
    }
}
