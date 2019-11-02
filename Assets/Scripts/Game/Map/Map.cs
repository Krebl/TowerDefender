using UnityEngine;

namespace Game
{
    public class Map : MonoBehaviour, IMap
    {

        [SerializeField] private CastleBehaviour _castle;
        [SerializeField] private Slot[] _slots;

        [SerializeField] private RouteEnemy _routeEnemy;
        [SerializeField] private Transform _containerForNPC;

        public ICastleBehaviour Castle => _castle;

        public IRouteEnemy RouteEnemy => _routeEnemy;
        public Transform ContainerForNpc => _containerForNPC;
    }
}

