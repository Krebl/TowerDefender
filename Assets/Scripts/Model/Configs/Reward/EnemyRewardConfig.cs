using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyRewardConfig", menuName = "Tower/Create EnemyRewardConfig")]
    public class EnemyRewardConfig : ScriptableObject, IReward
    {
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;

        public int GetReward => UnityEngine.Random.Range(_minValue, _maxValue);
    }
}

