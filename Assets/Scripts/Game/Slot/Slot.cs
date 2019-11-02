using UnityEngine;

namespace Game
{
    public class Slot : MonoBehaviour, ISlot
    {
        public ITowerBehaviour Tower { get; set; }
        public bool IsEmpty => Tower != null;

        private void OnClickSlot()
        {
            
        }

    }
}

