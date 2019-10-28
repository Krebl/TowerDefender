using System.Collections.Generic;
using Configs;

namespace Model
{
    public class EnemySpawn : IEnemySpawn
    {
        private float _timeBetweenSpawn = 1f;
        private float _timeFromLastSpawn;

        private int _maxEnemyForOneSpawn = 3;
        private int _minEnemyForOneSpawn = 1;

        private IEnemyConfig[] _availableConfigs;
        
        public EnemySpawn(IEnemyConfig[] enemyConfigs)
        {
            _availableConfigs = enemyConfigs;
        }
        
        
        public List<IEnemy> GetEnemyForSpawn(float secondsLeft)
        {
            bool isAvailable = IsAvailableSpawn(secondsLeft);

            if (!isAvailable)
            {
                return new List<IEnemy>();
            }

            _timeFromLastSpawn = 0;

            int countEnemy = GetCountEnemy;
            List<IEnemy> result = new List<IEnemy>();
            for (int i = 0; i < countEnemy; i++)
            {
                result.Add(new Enemy(GetEnemy));
            }

            return result;
        }

        private bool IsAvailableSpawn(float secondsLeft)
        {
            _timeFromLastSpawn += secondsLeft;
            return _timeFromLastSpawn >= _timeBetweenSpawn;
        }

        private int GetCountEnemy => UnityEngine.Random.Range(_minEnemyForOneSpawn, _maxEnemyForOneSpawn);

        private IEnemyConfig GetEnemy
        {
            get
            {
                int indexConfig = UnityEngine.Random.Range(0, _availableConfigs.Length);
                return _availableConfigs[indexConfig];
            }
        }
    }
}

