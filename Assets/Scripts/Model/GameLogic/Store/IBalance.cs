using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purchase
{
    public interface IBalance
    {
        int BalanceValue { get; set; }
        
        IObservable<int> OnChangeBalance { get; }
    }

}

