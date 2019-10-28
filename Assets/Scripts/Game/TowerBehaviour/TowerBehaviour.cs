using Configs;
using UnityEngine;
using Utils;

namespace Game
{
    public class TowerBehaviour : MonoBehaviour, ITowerBehaviour
    {
        private ITowerConfig _towerConfig;
    
        public void Init(ITowerConfig config)
        {
            _towerConfig = config;
        }

        private void OnTriggerEnter(Collider other)
        {
            OnDetectedEnemy(other);
        }

        private void OnDetectedEnemy(Collider other)
        {
            if (other.CompareTag(TagStorage.TagEnemy))
            {
                var enemy = other.GetComponent<IEnemyBehaviour>();

                if (enemy != null)
                {
                    GameRoot.Instance.GameLogic.DamageManager.SetDamage(enemy.EnemyData, _towerConfig.Damage);
                }
            }
        }
    }
}

