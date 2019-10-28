using System;
using Configs;


namespace Purchase
{
    public interface IGameStore
    {
        IBalance Balance { get; }
        
        IObservable<string> OnSuccessPurchase { get; }
        IObservable<string> OnFailedPurchase { get; }

        bool IsEnoughOnBalance(int cost);
        bool IsEnoughOnBalance(IPurchaseConfig config);

        void Purchase(IPurchaseConfig config);
        void Give(int size);
    }
}

