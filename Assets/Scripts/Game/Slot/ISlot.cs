using Configs;

namespace Game
{
    public interface ISlot
    {
        ITowerBehaviour Tower { get; }
        
        bool IsEmpty { get; }

        void FreeSlot();

        void CreateTower(ITowerConfig towerConfig);
    }
}

