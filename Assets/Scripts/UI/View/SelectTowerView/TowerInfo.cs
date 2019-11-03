using Configs;
using Game;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class TowerInfo : MonoBehaviour
    {
        [Header("Sprite")] 
        [SerializeField] private Image _avatar;
        
        [Header("Labels")]
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _damageText;
        [SerializeField] private TextMeshProUGUI _diameterText;
        [SerializeField] private TextMeshProUGUI _timeReloadText;

        [Header("Buttons")]
        [SerializeField] private Button _buttonBuy;

        private ITowerConfig _towerConfig;
        private ISlot _slot;
        
        public void Init(ITowerConfig towerConfig, ISlot slot)
        {
            _towerConfig = towerConfig;
            _slot = slot;

            _avatar.sprite = towerConfig.Avatar;

            _titleText.text = _towerConfig.NameTower;

            _damageText.text = _towerConfig.Damage.ToString();
            _diameterText.text = _towerConfig.DiameterAreaAttack.ToString();
            _timeReloadText.text = _towerConfig.SecondsBetweenShoot.ToString();

            Subscribe();
            SetActiveButtonBuy();

            GameRoot.Instance.GameLogic.Store.OnSuccessPurchase.Subscribe(OnSuccessPurchase).AddTo(this);
        }

        private void Subscribe()
        {
            _buttonBuy.OnClickAsObservable().Subscribe(_ => OnButtonBuyClick()).AddTo(this);
        }

        private void OnButtonBuyClick()
        {
            GameRoot.Instance.GameLogic.Store.Purchase(_towerConfig.PurchaseConfig);
        }

        private void OnSuccessPurchase(string id)
        {
            if (id == _towerConfig.PurchaseConfig.IdPurchase)
            {
                
            }
        }

        public void UpdateState()
        {
            SetActiveButtonBuy();
        }

        private void SetActiveButtonBuy()
        {
            _buttonBuy.enabled = _slot.IsEmpty &&
                                 GameRoot.Instance.GameLogic.Store.IsEnoughOnBalance(_towerConfig.PurchaseConfig);
        }
    }
}

