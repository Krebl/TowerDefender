using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AimTower : IAimTower
    {
        public IEnemyBehaviour SelectTarget(Dictionary<int, IEnemyBehaviour> variants)
        {
            float minDistance = float.MaxValue;
            IEnemyBehaviour target = null;
            
            Vector3 castle = Vector3.zero;;
            float currentDistance = 0;

            foreach (var variant in variants.Values)
            {
                if (variant == null)
                {
                    continue;
                }
                
                currentDistance = Vector3.Distance(castle, variant.Position);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    target = variant;
                } 
            }

            return target;
        }
    }
}

