
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Upgrades", menuName = "Scriptable Objects/Tower Upgrades", order = 0)]
public class TowerUpgrade : ScriptableObject, IStatsProvider<AttackStats>
{
    [SerializeField]
    private int _upgradeLevel;    
    [SerializeField]
    private TowerType _effectedTower;    

    [SerializeField]
    public int _minDamage;
    [SerializeField]
    public int _maxDamage;
    [SerializeField]
    public int _armorPiercing;
    [SerializeField]
    public float _range;
    [SerializeField]
    public float _aOE;
    [SerializeField]
    public float _reloadTime;
    [SerializeField]
    public bool _slow;

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
