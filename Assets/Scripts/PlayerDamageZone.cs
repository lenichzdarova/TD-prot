using System.Collections;
using UnityEngine;

public class PlayerDamageZone : MonoBehaviour
{
    private Health _playerHealth;

    public void Init(Health playerHealth)
    {
        _playerHealth = playerHealth;
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.AttackPlayer(_playerHealth);
        }        
    }
}
