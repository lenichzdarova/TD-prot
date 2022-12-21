using System.Collections;
using UnityEngine;

public class PlayerDamageZone : MonoBehaviour
{
    private IPlayerHealthProvider playerHealthProvider;

    public void Init(IPlayerHealthProvider iPlayerHealthProvider)
    {
        playerHealthProvider = iPlayerHealthProvider;
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.AttackPlayer(playerHealthProvider);
        }        
    }
}
