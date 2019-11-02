
namespace Game
{
    public interface IMoverEnemy
    {
        void Move();
        float Speed { get; set; }

        void StartMove();
    }
}

