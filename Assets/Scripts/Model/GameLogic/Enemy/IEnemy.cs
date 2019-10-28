using System.Collections;
using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Model
{
    public interface IEnemy : IReceiveDamage
    {
        IEnemyConfig EnemyConfig { get; }
    }
}

