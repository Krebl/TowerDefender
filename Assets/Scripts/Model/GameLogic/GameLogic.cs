using Configs;
using Purchase;


namespace Model
{
    public class GameLogic
    {
        public IPlayer Player { get; }
        
        public IDamageManager DamageManager { get; }
        
        public IEnemySpawn EnemySpawn { get; }
        
        public IGameStore Store { get; }
        public IGameConfig GameConfig => _gameConfig;

        private IGameConfig _gameConfig;
        
        public GameLogic(IGameConfig config)
        {
            
            _gameConfig = config;
            
            Player = new Player();
            Player.CastleConfig = config.CastleConfig;
            
            DamageManager = new DamageManager();
            EnemySpawn = new EnemySpawn(config.EnemyConfigs);
            
            Store = new GameStore();
        }
    }
}

