using Model;
using UniRx;

namespace Game
{
    public interface ISpawnBehaviour
    {
        void Init(IEnemySpawn enemySpawn, IMap map);

        void DestroyEnemy(int enemyId);
        
        ISubject<int> OnDestroyEnemy { get; }
    }
}

