using Configs;


namespace Model
{
    public interface IPlayer : IReceiveDamage
    {
        ICastleConfig CastleConfig { get; set; }
    }
}

