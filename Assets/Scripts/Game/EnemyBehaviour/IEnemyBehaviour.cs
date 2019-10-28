using Model;

namespace Game
{
    public interface IEnemyBehaviour
    {
        void Init(IEnemy enemy);
        void DestroyEnemy();
        
        IEnemy EnemyData { get; }
    }
}

