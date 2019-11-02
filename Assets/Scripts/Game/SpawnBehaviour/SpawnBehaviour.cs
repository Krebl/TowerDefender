using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Game
{
    public class SpawnBehaviour : MonoBehaviour, ISpawnBehaviour
    {
        private int _currentIndexEnemy;
        private bool _isActivate;
        private IEnemySpawn _enemySpawn;
        private IMap _map;

        private float _delayBetweenActivate = 0.3f;

        private void IncreaseIndex()
        {
            _currentIndexEnemy++;
            
            if (_currentIndexEnemy >= int.MaxValue)
            {
                _currentIndexEnemy = 0;
            }
        }

        public void Init(IEnemySpawn enemySpawn, IMap map)
        {
            _isActivate = true;
            _enemySpawn = enemySpawn;
            _map = map;
        }

        public void Activate()
        {
            _isActivate = true;
        }

        private void Update()
        {
            if (_isActivate)
            {
               List<IEnemy> enemies = _enemySpawn.GetEnemyForSpawn(Time.deltaTime);

               for (int i = 0; i < enemies.Count; i++)
               {
                   CreateEnemy(i, enemies[i]);
               }
            }
        }

        private void CreateEnemy(int numberInsideCurrentSpawn, IEnemy enemy)
        {
            float currentDelay = _delayBetweenActivate * numberInsideCurrentSpawn;

            GameObject gameObjectEnemy = Instantiate(enemy.EnemyConfig.PrefabEnemy, _map.ContainerForNpc, false);
            IEnemyBehaviour enemyBehaviour = gameObjectEnemy.GetComponent<IEnemyBehaviour>();
            
            enemyBehaviour.Init(enemy, _currentIndexEnemy);
            enemyBehaviour.MoverEnemy = new MoveEnemyOnRoute(_map.RouteEnemy, enemyBehaviour.CachedTransform);
            enemyBehaviour.ActivateEnemy(currentDelay);
            
            IncreaseIndex();
        }
    }
}

