using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Tower/Create TowerConfig")]
    public class TowerConfig : ScriptableObject, ITowerConfig
    {
        [Header("Prefab")] 
        [SerializeField] private GameObject _prefabTower;
        
        
        [Header("Settings")]
        [SerializeField] private float _diameterAreaAttack;
        [SerializeField] private float _secondsBetweenShoot;
        [SerializeField] private int _damage;

        [Header("Purchase config")] 
        [SerializeField] private PurchaseConfig _purchaseConfig;
        
        
        public float DiameterAreaAttack => _diameterAreaAttack;
        public float SecondsBetweenShoot => _secondsBetweenShoot;
        public int Damage => _damage;
        public GameObject PrefabTower => _prefabTower;

        public IPurchaseConfig PurchaseConfig => _purchaseConfig;
    }
}

