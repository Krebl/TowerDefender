using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game
{
    public class Radar : MonoBehaviour, IRadar
    {
        [SerializeField] private SphereCollider _detectArea;
        
        private Dictionary<int, IEnemyBehaviour> _trackedEnemies;

        public Dictionary<int, IEnemyBehaviour> TrackedEnemies => _trackedEnemies;
        private bool _isActiveRadar = false;

        public void Init(float diameterDetectedArea)
        {
            _trackedEnemies = new Dictionary<int, IEnemyBehaviour>();
            _detectArea.radius = diameterDetectedArea / 2;
            _isActiveRadar = true;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (_isActiveRadar)
            {
                DetectEnemy(other, StartTrackEnemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_isActiveRadar)
            {
                DetectEnemy(other, StopTrackEnemy);
            }
        }

        private void DetectEnemy(Collider collider, Action<IEnemyBehaviour> actionWithEnemy)
        {
            if (collider.CompareTag(TagStorage.TagEnemy))
            {
                IEnemyBehaviour enemy = collider.GetComponent<IEnemyBehaviour>();
                actionWithEnemy?.Invoke(enemy);
            }
        }

        private void StartTrackEnemy(IEnemyBehaviour enemy)
        {
            if (!_trackedEnemies.ContainsKey(enemy.NumberObject))
            {
                _trackedEnemies.Add(enemy.NumberObject, enemy);  
            }
        }

        private void StopTrackEnemy(IEnemyBehaviour enemy)
        {
            if (!_trackedEnemies.ContainsKey(enemy.NumberObject))
            {
                _trackedEnemies.Remove(enemy.NumberObject);
            }
        }
    }
}

