using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Tower/Create EnemyConfig")]
    public class EnemyConfig : ScriptableObject, IEnemyConfig
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject _prefabEnemy;

        [Header("Settings")] 
        [SerializeField] private string _id;
        [SerializeField] private int _healthAmount;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        [Header("Reward")] 
        [SerializeField] private EnemyRewardConfig _reward;

        public string Id => _id;
        
        public GameObject PrefabEnemy => _prefabEnemy;
        
        public int HealthAmount => _healthAmount;
        public float Speed => _speed;
        public int Damage => _damage;

        public IReward RewardConfig => _reward;
    }
}

