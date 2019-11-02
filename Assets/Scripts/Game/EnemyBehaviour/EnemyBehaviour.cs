using System;
using Model;
using UniRx;
using UnityEngine;

namespace Game
{
    public class EnemyBehaviour : MonoBehaviour, IEnemyBehaviour
    {
        [SerializeField] private Transform _cachedTransform;

        private bool _isActivate = false;
        private IEnemy _enemy;

        public int NumberObject { get; private set; }

        public Vector3 Position => _cachedTransform.position;
        public IMoverEnemy MoverEnemy { get; set; }
        public void ActivateEnemy(float delay)
        {
            Observable.Start(() => _isActivate = true).Delay(TimeSpan.FromSeconds(delay));
        }

        public Transform CachedTransform => _cachedTransform;

        public void Init(IEnemy enemy, int numberObject)
        {
            NumberObject = numberObject;
            _enemy = enemy;
            
            _isActivate = true;
            GameRoot.Instance.GameLogic.DamageManager.OnKilled.Subscribe(OnDeath).AddTo(this);
        }

        private void Update()
        {
            if (_isActivate)
            {
                MoverEnemy.Move();
            }
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

