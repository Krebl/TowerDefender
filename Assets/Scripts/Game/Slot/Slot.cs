using Configs;
using UnityEngine;
using UnityEngine.EventSystems;
using View;

namespace Game
{
    public class Slot : MonoBehaviour, ISlot, IPointerClickHandler
    {
        public ITowerBehaviour Tower { get; private set; }
        public bool IsEmpty => Tower == null;
        public void FreeSlot()
        {
            GameObject.Destroy(Tower.TowerObject);
        }

        private void OnClickSlot()
        {
            var view = NavigationView.Instance.PushView<SelectTowerView>(isHidePreviousWindow: false, isImmediatelyShow: false);

            if (view != null)
            {
                view.SetSlot(this);
                view.Show();
            }
        }

        public void CreateTower(ITowerConfig towerConfig)
        {
            if (!IsEmpty)
            {
                return;
            }
            
            GameObject towerObject = Instantiate(towerConfig.PrefabTower, transform.parent, false);
            Tower = towerObject.GetComponent<ITowerBehaviour>();
            Tower.TowerObject.transform.position = transform.position;
            Tower.Init(towerConfig);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickSlot();
        }
    }
}

