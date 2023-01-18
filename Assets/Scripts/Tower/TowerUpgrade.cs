
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Upgrades", menuName = "Scriptable Objects/Tower Upgrades", order = 0)]
public class TowerUpgrade : ScriptableObject, IStatsProvider<AttackStats>
{
    [SerializeField]
    private int _upgradeLevel;    
    [SerializeField]
    private TowerType _effectedTower;    

    [SerializeField]
    private int _minDamage;
    [SerializeField]
    private int _maxDamage;
    [SerializeField]
    private int _armorPiercing;
    [SerializeField]
    private float _range;
    [SerializeField]
    private float _aOE;
    [SerializeField]
    private float _reloadTime;
    [SerializeField]
    private bool _slow;

    public int GetUpgradeLevel()
    {
        return _upgradeLevel;
    }
    public TowerType GetTowerType()
    {
        return _effectedTower;
    }
    public AttackStats GetStats()
    {
        return new AttackStats
        {
            MinDamage = _minDamage,
            MaxDamage = _maxDamage,
            ArmorPiercing = _armorPiercing,
            Range = _range,
            AOE = _aOE,
            ReloadTime = _reloadTime,
            Slow = _slow
        };            
    }    
}
