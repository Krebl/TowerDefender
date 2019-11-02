using UnityEngine;

namespace Game
{
    public interface IRouteEnemy
    {
        Transform[] Points { get; }
        Vector3 GetPositionPoint(int number);

        bool IsFinish(int number);
    }
}

