using UnityEngine;

namespace View
{
	public abstract class BaseView : MonoBehaviour
	{
		protected abstract void Init();
		protected abstract void Dispose();
			
		public virtual void Show()
		{
			gameObject.SetActive(true);
		}

		public virtual void Hide()
		{
			gameObject.SetActive(false);
		}

		public virtual void CloseView()
		{
			Destroy(gameObject);
		}

		private void Awake()
		{
			Init();
		}

		private void OnDestroy()
		{
			Dispose();
		}
	}
}

