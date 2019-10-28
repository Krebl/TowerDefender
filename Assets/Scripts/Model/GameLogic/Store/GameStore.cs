using System;
using Configs;
using UniRx;


namespace Purchase
{
    public class GameStore : IGameStore
    {
        public IBalance Balance { get; }
        public IObservable<string> OnSuccessPurchase => _onSuccessPurchase;
        public IObservable<string> OnFailedPurchase => _onFailedPurchase;

        private Subject<string> _onSuccessPurchase;
        private Subject<string> _onFailedPurchase;

        public GameStore()
        {
            Balance = new Balance();
            _onSuccessPurchase = new Subject<string>();
            _onFailedPurchase = new Subject<string>();
        }

        public bool IsEnoughOnBalance(int cost)
        {
            return cost < Balance.BalanceValue;
        }

        public bool IsEnoughOnBalance(IPurchaseConfig config)
        {
            return config.Cost < Balance.BalanceValue;
        }

        public void Purchase(IPurchaseConfig config)
        {
            if (IsEnoughOnBalance(config))
            {
                Balance.BalanceValue -= config.Cost;
            }
        }

        public void Give(int size)
        {
            Balance.BalanceValue += size;
        }
    }
}

