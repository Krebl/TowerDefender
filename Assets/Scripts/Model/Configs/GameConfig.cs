using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Tower/Create GameConfig")]
    public class GameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] private TowerConfig[] _towerConfig;
        [SerializeField] private EnemyConfig[] _enemyConfigs;

        [SerializeField] private CastleConfig _castleConfig;

        public ITowerConfig[] TowerConfigs => _towerConfig;
        public IEnemyConfig[] EnemyConfigs => _enemyConfigs;
        public ICastleConfig CastleConfig => _castleConfig;
    }
}

