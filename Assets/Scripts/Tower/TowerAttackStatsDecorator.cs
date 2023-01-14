

public abstract class TowerAttackStatsDecorator : IStatsProvider<AttackStats>
{
   protected readonly IStatsProvider<AttackStats> _statsProvider;

    public TowerAttackStatsDecorator(IStatsProvider<AttackStats> statsProvider)
    {
        _statsProvider = statsProvider;
    }

    public abstract AttackStats GetStats();
}
