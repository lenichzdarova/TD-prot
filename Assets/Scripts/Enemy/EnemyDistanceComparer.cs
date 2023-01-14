
using System.Collections.Generic;

public class EnemyDistanceComparer : IComparer<Enemy>
{
    public int Compare(Enemy a, Enemy b)
    {
        return a.GetDistanceToPlayerBase().CompareTo(b.GetDistanceToPlayerBase());
    }
}
