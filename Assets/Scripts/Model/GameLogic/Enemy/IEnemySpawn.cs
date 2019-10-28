using System.Collections.Generic;

namespace Model
{
    public interface IEnemySpawn
    {
        List<IEnemy> GetEnemyForSpawn(float secondsLeft);
    }
}

