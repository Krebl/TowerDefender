using System.Collections.Generic;
using Configs;
using Game;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class SelectTowerView : BaseView
    {
        [SerializeField] private TowerInfo _towerInfoPrefab;
        [SerializeField] private Transform _parentTowerInfo;
        
        [SerializeField] private Button _buttonToSellTower;
        [SerializeField] private Button _buttonCloseView;
        
        private ISlot _slot;

        private List<TowerInfo> _createdTowerInfo;

        protected override void Init()
        {
            _createdTowerInfo = new List<TowerInfo>();
            Subscribe();

            GameRoot.Instance.GameLogic.Store.Balance.OnChangeBalance.Subscribe(OnBalanceChange).AddTo(this);
        }

        public void SetSlot(ISlot slot)
        {
            _slot = slot;
            CreateAllTowerInfo();
            _buttonToSellTower.enabled = !_slot.IsEmpty;
        }

        protected override void Dispose()
        {
            
        }

        private void CreateAllTowerInfo()
        {
            ITowerConfig[] availableConfigs = GameRoot.Instance.GameLogic.GameConfig.TowerConfigs;

            for (int i = 0; i < availableConfigs.Length; i++)
            {
                CreateTowerInfo(availableConfigs[i]);
            }
        }

        private void CreateTowerInfo(ITowerConfig config)
        {
            TowerInfo towerInfo = Instantiate(_towerInfoPrefab, _parentTowerInfo, false);
            towerInfo.Init(config, _slot);
            
            _createdTowerInfo.Add(towerInfo);
        }

        private void Subscribe()
        {
            _buttonToSellTower.OnClickAsObservable().Subscribe(_ => OnButtonToSellClick()).AddTo(this);
            _buttonCloseView.OnClickAsObservable().Subscribe(_ => OnButtonCloseClick()).AddTo(this);
        }

        private void OnButtonToSellClick()
        {
            int cost = _slot.Tower.TowerConfig.PurchaseConfig.Cost;
            GameRoot.Instance.GameLogic.Store.Give(cost);
            _slot.FreeSlot();
        }

        private void OnButtonCloseClick()
        {
            NavigationView.Instance.PopView();
        }

        private void OnBalanceChange(int size)
        {
            _buttonToSellTower.enabled = !_slot.IsEmpty;

            for (int i = 0; i < _createdTowerInfo.Count; i++)
            {
                _createdTowerInfo[i].UpdateState();
            }
        }
    }
}

