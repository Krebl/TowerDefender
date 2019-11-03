using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameView : BaseView
    {
        [SerializeField] private TextMeshProUGUI _balanceText;
        [SerializeField] private Button _buttonStartGame;
        
        protected override void Init()
        {
            GameRoot.Instance.GameLogic.Store.Balance.OnChangeBalance.Subscribe(OnChangeBalance).AddTo(this);
            Subscribe();
        }

        protected override void Dispose()
        {
            
        }

        private void OnChangeBalance(int size)
        {
            _balanceText.text = size.ToString();
        }

        private void Subscribe()
        {
            _buttonStartGame.OnClickAsObservable().Subscribe(_ => OnButtonStartGameClick()).AddTo(this);
        }

        private void OnButtonStartGameClick()
        {
            GameRoot.Instance.GameLogic.StartGame();
            _buttonStartGame.enabled = false;
        }
    }
}

