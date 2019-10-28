using System;
using Model;

public interface IDamageManager
{
   IObservable<string> OnKilled { get; }

    void SetDamage(IReceiveDamage damagedObject, int damage);
}
