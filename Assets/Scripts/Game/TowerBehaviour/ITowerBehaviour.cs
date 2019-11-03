using Configs;
using UnityEngine;

namespace Game
{
    public interface ITowerBehaviour
    {
        void Init(ITowerConfig config);
        
        GameObject TowerObject { get; }
        
        ITowerConfig TowerConfig { get; }
    }
}

