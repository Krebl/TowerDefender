using System.Collections.Generic;

namespace Game
{
    public interface IRadar
    {
        void Init(float diameterDetectedArea);

        Dictionary<int, IEnemyBehaviour> TrackedEnemies { get; }
    }  
}

