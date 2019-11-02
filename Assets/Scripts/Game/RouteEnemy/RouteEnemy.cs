using UnityEngine;

namespace Game
{
    public class RouteEnemy : MonoBehaviour, IRouteEnemy
    {
        [SerializeField] private Transform[] _points;

        public Transform[] Points => _points;

        public Vector3 GetPositionPoint(int number)
        {
            if (number >= _points.Length)
            {
                return _points[_numberLastPoint].position;
            }

            return _points[number].position;
        }

        public bool IsFinish(int number)
        {
            return number >= _numberLastPoint;
        }

        private int _numberLastPoint => _points.Length - 1;
    }
}

