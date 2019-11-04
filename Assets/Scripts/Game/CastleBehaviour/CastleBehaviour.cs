using Model;
using UniRx;
using UnityEngine;
using Utils;
using View;

namespace Game
{
    public class CastleBehaviour : MonoBehaviour, ICastleBehaviour
    {
        private IPlayer _player;
        
        public void Init(IPlayer player)
        {
            _player = player;
            GameRoot.Instance.GameLogic.DamageManager.OnKilled.Subscribe(OnDeath).AddTo(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnEnemyCollision(other);
        }

        private void OnEnemyCollision(Collider other)
        {
            if (other.CompareTag(TagStorage.TagEnemy))
            {
                var  enemy = other.GetComponent<IEnemyBehaviour>();

                if (enemy != null)
                {
                    GameRoot.Instance.GameLogic.DamageManager.SetDamage(_player, enemy.EnemyData.EnemyConfig.Damage);
                    enemy.DestroyEnemy();
                }
            }
        }

        private void OnDeath(string id)
        {
            if (id == _player.Id)
            {
                GameReport.CurrentState = GameReport.GameState.GameOver;
                NavigationView.Instance.PushView<GameOverView>();
            }
        }
    }
}

