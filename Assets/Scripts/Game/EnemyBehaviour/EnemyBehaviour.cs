using Model;
using UniRx;
using UnityEngine;

namespace Game
{
    public class EnemyBehaviour : MonoBehaviour, IEnemyBehaviour
    {
        [SerializeField] private Transform _cachedTransform;

        private bool _isMoving = false;
        private IEnemy _enemy;
        private Vector3 _currentDirection;
        
        public void Init(IEnemy enemy)
        {
            _enemy = enemy;
            _isMoving = true;
            GameRoot.Instance.GameLogic.DamageManager.OnKilled.Subscribe(OnDeath).AddTo(this);
        }

        private void Update()
        {
            if (_isMoving)
            {
                Move();
            }
        }

        private void Move()
        {
            float valueSpeed = Time.deltaTime * _enemy.EnemyConfig.Speed;
            _cachedTransform.position = _currentDirection * valueSpeed;
        }

        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }

        public IEnemy EnemyData => _enemy;

        private void OnDeath(string id)
        {
            if (id == _enemy.Id)
            {
                GameRoot.Instance.GameLogic.Store.Give(_enemy.EnemyConfig.RewardConfig.GetReward);
                DestroyEnemy();
            }
        }
    }
}

