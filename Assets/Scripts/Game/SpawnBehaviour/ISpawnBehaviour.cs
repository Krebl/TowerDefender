using Model;

namespace Game
{
    public interface ISpawnBehaviour
    {
        void Init(IEnemySpawn enemySpawn, IMap map);

        void Activate();
    }
}

