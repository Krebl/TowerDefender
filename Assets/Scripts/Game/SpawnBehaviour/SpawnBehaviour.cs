using System.Collections.Generic;
using Model;
using UniRx;
using UnityEngine;

namespace Game
{
    public class SpawnBehaviour : MonoBehaviour, ISpawnBehaviour
    {
        private int _currentIndexEnemy;
        private IEnemySpawn _enemySpawn;
        private IMap _map;

        private Dictionary<int, IEnemyBehaviour> _enemyBehaviours;
        private float _delayBetweenActivate = 0.5f;

        public ISubject<int> OnDestroyEnemy { get; private set; }

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
            OnDestroyEnemy = new Subject<int>();
            _enemyBehaviours = new Dictionary<int, IEnemyBehaviour>();
            
            _enemySpawn = enemySpawn;
            _map = map;
        }

        public void DestroyEnemy(int numberEnemy)
        {
            if(_enemyBehaviours.ContainsKey(numberEnemy))
            {
                _enemyBehaviours.Remove(numberEnemy);
                OnDestroyEnemy.OnNext(numberEnemy);
            }
        }

        private void Update()
        {
            if (GameReport.IsPlaying)
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
            //0 стартовая позиция
            enemyBehaviour.CachedTransform.position = _map.RouteEnemy.GetPositionPoint(0);
            _enemyBehaviours.Add(enemyBehaviour.NumberObject, enemyBehaviour);
            
            IncreaseIndex();
        }
    }
}

