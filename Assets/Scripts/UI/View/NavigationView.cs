using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class NavigationView : Singleton<NavigationView>
    {
        public Transform ParentForView;
        private readonly Stack<BaseView> _viewStack = new Stack<BaseView>();


        public T PushView<T>(bool isHidePreviousWindow = true, bool isImmediatelyShow = true) where T : BaseView
        {
            GameObject prefab = Instantiate(PrefabViewLoad.LoadView(typeof(T)));

            if (prefab != null)
            {
                prefab.transform.SetParent(ParentForView, false);
                var view = prefab.GetComponent<T>();

                if (_viewStack.Count > 0 && isHidePreviousWindow)
                { 
                    _viewStack.Peek().Hide(); 
                }

                _viewStack.Push(view);

                if (isImmediatelyShow)
                {
                    view.Show();
                }

                
                return view;
            }

            return null;
        }

        public void PopView()
        {
            var view = _viewStack.Pop();
            view.CloseView();

            if (_viewStack.Count > 0)
            {
                _viewStack.Peek().Show();
            }
        }
    }
}