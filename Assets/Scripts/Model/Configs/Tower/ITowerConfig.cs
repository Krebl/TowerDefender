using UnityEngine;

namespace Configs
{
    public interface ITowerConfig
    {
        string NameTower { get; }
        Sprite Avatar { get; }
        
        float DiameterAreaAttack { get; }
        float SecondsBetweenShoot { get; }
        int Damage { get; }
        
        GameObject PrefabTower { get; }
        
        IPurchaseConfig PurchaseConfig { get; }
    }
}

