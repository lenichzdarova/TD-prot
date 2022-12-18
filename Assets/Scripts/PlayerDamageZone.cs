using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerDamageZone : MonoBehaviour
    {
        private IPlayerDamage iPlayerDamage;        

        public void Init( IPlayerDamage iPlayerDamage)
        {
            this.iPlayerDamage = iPlayerDamage;            
        }

        private void OnTriggerEnter(Collider other)
        {            
            if (other.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.AttackPlayer(iPlayerDamage);
            }
        }
    }
}