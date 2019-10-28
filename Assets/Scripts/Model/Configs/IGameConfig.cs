
namespace Configs
{
    public interface IGameConfig
    {
        ITowerConfig[] TowerConfigs { get; }
        IEnemyConfig[] EnemyConfigs { get; }
        
        ICastleConfig CastleConfig { get; }
    }
}

