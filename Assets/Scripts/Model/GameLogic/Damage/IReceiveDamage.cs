
namespace Model
{
    public interface IReceiveDamage
    {
        string Id { get; }
        int HealthAmount { get; }

        void ReceiveDamage(int damage);
    }
}

