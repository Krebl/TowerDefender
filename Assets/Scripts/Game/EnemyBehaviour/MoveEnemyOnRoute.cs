using UnityEngine;
using Utils;

namespace Game
{
    public class MoveEnemyOnRoute : MonoBehaviour, IMoverEnemy
    {
        private IRouteEnemy _route;
        private Transform _enemyTransform;

        private Rigidbody _rigidbody;
        
        public MoveEnemyOnRoute(IRouteEnemy routeEnemy, Transform enemyTransform)
        {
            _route = routeEnemy;
            _enemyTransform = enemyTransform;

            _rigidbody = enemyTransform.GetComponent<Rigidbody>();
        }
        
        public float Speed { get; set; }
        private bool _isMoving = false;
        private int _pointRoute = 0;
        
        private Vector3 _prevPosition = Vector3.zero;
        
        public void Move()
        {
            if (_isMoving)
            {

                
                Vector3 position =
                    Vector2.MoveTowards(_enemyTransform.position, _route.GetPositionPoint(_pointRoute),
                        Time.deltaTime * Speed);
                position = ClampUtils.ClampVector(position, _prevPosition, _route.GetPositionPoint(_pointRoute));

                _rigidbody.MovePosition(position);

                if (position.Equals(_route.GetPositionPoint(_pointRoute)))
                {
                    if (_route.IsFinish(_pointRoute))
                    {
                        _isMoving = false;
                        _rigidbody.velocity = Vector3.zero;
                        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    }
                    else
                    {
                        _prevPosition = _enemyTransform.position;
                        _pointRoute++;
                    }
                }
            }
        }

        public void StartMove()
        {
            _prevPosition = _enemyTransform.position;
            _isMoving = true;
        }
    }
}

