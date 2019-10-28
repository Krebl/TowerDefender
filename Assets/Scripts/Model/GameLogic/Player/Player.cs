using Configs;

namespace Model
{
    public class Player : IPlayer
    {
        public string Id => CastleConfig.Id;
        public int HealthAmount { get; private set; }

        private ICastleConfig _castleConfig;
        
        public void ReceiveDamage(int damage)
        {
            HealthAmount -= damage;
        }

        public ICastleConfig CastleConfig
        {
            get => _castleConfig;
            set
            {
                _castleConfig = value;

                if (_castleConfig != null)
                {
                    HealthAmount = _castleConfig.HealthAmount;
                }
            }
        }
        
        
    }
}

