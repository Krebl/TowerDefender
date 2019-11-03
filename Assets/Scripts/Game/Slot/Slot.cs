using UnityEngine;
using UnityEngine.EventSystems;
using View;

namespace Game
{
    public class Slot : MonoBehaviour, ISlot, IPointerClickHandler
    {
        public ITowerBehaviour Tower { get; set; }
        public bool IsEmpty => Tower != null;
        public void FreeSlot()
        {
            GameObject.Destroy(Tower.TowerObject);
        }

        private void OnClickSlot()
        {
            var view = NavigationView.Instance.PushView<SelectTowerView>(isImmediatelyShow: false);

            if (view != null)
            {
                view.SetSlot(this);
                view.Show();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickSlot();
        }
    }
}

