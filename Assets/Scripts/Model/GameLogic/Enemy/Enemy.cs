using Configs;

namespace Model
{
    public class Enemy : IEnemy
    {
        private IEnemyConfig _enemyConfig;
        
        public Enemy(IEnemyConfig config)
        {
            _enemyConfig = config;
            HealthAmount = config.HealthAmount;
        }

        public IEnemyConfig EnemyConfig => _enemyConfig;

        public string Id => _enemyConfig.Id;
        public int HealthAmount { get; private set; }
        public void ReceiveDamage(int damage)
        {
            HealthAmount -= damage;
        }
    }
}

