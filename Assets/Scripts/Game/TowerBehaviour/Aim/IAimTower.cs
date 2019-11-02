using System.Collections.Generic;

namespace Game
{
    public interface IAimTower
    {
        IEnemyBehaviour SelectTarget(Dictionary<int, IEnemyBehaviour> variants);
    } 
}

