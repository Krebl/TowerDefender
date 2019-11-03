using UnityEngine;

namespace Configs
{
    //теоретически тут может содержаться также: тип валюты(премиум и обычная), идентификатор покупки,
    //поэтому сделано отдельныи конфигом 
    
    [CreateAssetMenu(fileName = "PurchaseConfig", menuName = "Tower/Create PurchaseConfig")]
    public class PurchaseConfig : ScriptableObject, IPurchaseConfig
    {
        [SerializeField] private string _idPurchase;
        [SerializeField] private int _cost;

        public int Cost => _cost;

        public string IdPurchase => _idPurchase;
    }  
}

