
namespace Game
{
    public interface ISlot
    {
        ITowerBehaviour Tower { get; set; }
        
        bool IsEmpty { get; }

        void FreeSlot();
    }
}

