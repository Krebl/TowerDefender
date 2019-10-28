using Configs;


namespace Model
{
    public class GameLogic
    {
        public IPlayer Player { get; }
        
        public IDamageManager DamageManager { get; }
        
        public IEnemySpawn EnemySpawn { get; }

        private IGameConfig _gameConfig;
        
        public GameLogic(IGameConfig config)
        {
            _gameConfig = config;
            
            Player = new Player();
            Player.CastleConfig = config.CastleConfig;
            
            DamageManager = new DamageManager();
            EnemySpawn = new EnemySpawn(config.EnemyConfigs);
        }
    }
}

