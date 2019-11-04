using System;
using UniRx;


namespace Purchase
{
    public class Balance : IBalance
    {
        private ReactiveProperty<int> _balanceProperty;
        private int _defaultBalance = 100;
        
        public Balance()
        {
            _balanceProperty = new ReactiveProperty<int>();
            BalanceValue = _defaultBalance;
        }


        public int BalanceValue
        {
            get => _balanceProperty.Value;
            set => _balanceProperty.Value = value;
        }

        public IObservable<int> OnChangeBalance => _balanceProperty;
    }
}

