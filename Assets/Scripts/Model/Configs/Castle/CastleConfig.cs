using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "CastleConfig", menuName = "Tower/Create CastleConfig")]
    public class CastleConfig : ScriptableObject, ICastleConfig
    {
        [SerializeField] private string _id;
        [SerializeField] private int _healthAmount;

        public int HealthAmount => _healthAmount;
        public string Id => _id;
    } 
}

