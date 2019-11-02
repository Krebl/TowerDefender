
using UnityEngine;

namespace Game
{
    public interface IMap
    {
        ICastleBehaviour Castle { get; }
        
        IRouteEnemy RouteEnemy { get; }
        
        Transform ContainerForNpc { get; }
    }
}

