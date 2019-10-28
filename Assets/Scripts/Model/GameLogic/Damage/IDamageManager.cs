using System;
using Model;

public interface IDamageManager
{
    Action<string>  OnKilled { get; set; }

    void SetDamage(IReceiveDamage damagedObject, int damage);
}
