using System;

namespace Model
{
    public class DamageManager : IDamageManager
    {
        public Action<string>  OnKilled { get; set; }
        
        public void SetDamage(IReceiveDamage damagedObject, int damage)
        {
            damagedObject.ReceiveDamage(damage);

            if (damagedObject.HealthAmount <= 0)
            {
                OnKilled?.Invoke(damagedObject.Id);
            }
        }
    }
}

