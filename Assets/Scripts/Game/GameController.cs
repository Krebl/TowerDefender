using System;
using Model;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private IMap _map;

        [SerializeField] private Transform _gameRoot;
        [SerializeField] private string[] _pathsToMap;
        [SerializeField] private SpawnBehaviour _spawnBehaviour;

        public SpawnBehaviour SpawnBehaviour => _spawnBehaviour;

        private void CreateMap(int indexMap)
        {
            if (_pathsToMap.Length <= 0)
            {
                Debug.LogException(new Exception("path to maps is empty"));
            }
            
            
            if (indexMap <= _pathsToMap.Length)
            {
                indexMap = 0;
            }

            Map prefabMap = Resources.Load<Map>(_pathsToMap[indexMap]);
            _map = Instantiate(prefabMap, _gameRoot, false);
        }

        public void CreateLevel(GameLogic logic)
        {
            //0 так как карта только 1
            CreateMap(0);
            
            _map.Castle.Init(logic.Player);
            _spawnBehaviour.Init(logic.EnemySpawn, _map);
            
        }

        public void StartGame()
        {
            GameReport.CurrentState = GameReport.GameState.Playing;
        }
    }
}

