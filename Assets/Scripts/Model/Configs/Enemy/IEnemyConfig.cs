using UnityEngine;

namespace Configs
{
    public interface IEnemyConfig
    {
        string Id { get; }
        
        GameObject PrefabEnemy { get; }
        int HealthAmount { get; }
        float Speed { get; }
        int Damage { get; }
        
        IReward RewardConfig { get; }
    }
}

