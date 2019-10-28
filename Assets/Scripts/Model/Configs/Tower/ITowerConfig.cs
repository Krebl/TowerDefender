using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    public interface ITowerConfig
    {
        float DiameterAreaAttack { get; }
        float SecondsBetweenShoot { get; }
        int Damage { get; }
        
        GameObject PrefabTower { get; }
        
        IPurchaseConfig PurchaseConfig { get; }
    }
}

