using System;
using Configs;
using UniRx;
using UnityEngine;
using Utils;

namespace Game
{
    public class TowerBehaviour : MonoBehaviour, ITowerBehaviour
    {
        [SerializeField] private Radar _radar;

        private ITowerConfig _towerConfig;
        private IDisposable _reloadTimer;
        private IAimTower _aim;

        private bool _isActive = false;

        public ITowerConfig TowerConfig => _towerConfig;

        public void Init(ITowerConfig config)
        {
            _aim = new AimTower();
            _towerConfig = config;
            _radar.Init(_towerConfig.DiameterAreaAttack);
            
            Observable.Interval(TimeSpan.FromSeconds(_towerConfig.SecondsBetweenShoot))
                .Where(_ => _isActive).Subscribe(_ => Shoot()).AddTo(this);
        }

        public GameObject TowerObject { get; }

        public void ActivateTower()
        {
            _isActive = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            OnDetectedEnemy(other);
        }

        private void OnDetectedEnemy(Collider other)
        {
            if (other.CompareTag(TagStorage.TagEnemy))
            {
                var enemy = other.GetComponent<IEnemyBehaviour>();

                if (enemy != null)
                {
                    GameRoot.Instance.GameLogic.DamageManager.SetDamage(enemy.EnemyData, _towerConfig.Damage);
                }
            }
        }

        private void Shoot()
        {
            IEnemyBehaviour selectedEnemy = _aim.SelectTarget(_radar.TrackedEnemies);

            if (selectedEnemy != null)
            {
                GameRoot.Instance.GameLogic.DamageManager.SetDamage(selectedEnemy.EnemyData, _towerConfig.Damage);
            }
        }
    }
}

