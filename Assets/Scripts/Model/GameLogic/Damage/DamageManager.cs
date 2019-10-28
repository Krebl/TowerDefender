using System;
using UniRx;

namespace Model
{
    public class DamageManager : IDamageManager
    {
        public IObservable<string> OnKilled => _onKilled;

        private Subject<string> _onKilled;

        public DamageManager()
        {
            _onKilled = new Subject<string>();
        }
        
        public void SetDamage(IReceiveDamage damagedObject, int damage)
        {
            damagedObject.ReceiveDamage(damage);

            if (damagedObject.HealthAmount <= 0)
            {
                _onKilled.OnNext(damagedObject.Id);
            }
        }
    }
}

