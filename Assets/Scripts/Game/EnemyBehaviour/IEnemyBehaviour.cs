using UnityEngine;
using Model;

namespace Game
{
    public interface IEnemyBehaviour
    {
        int NumberObject { get; }
        void Init(IEnemy enemy, int numberObject);
        void DestroyEnemy();
        
        IEnemy EnemyData { get; }
        
        Vector3 Position { get; }
    }
}

