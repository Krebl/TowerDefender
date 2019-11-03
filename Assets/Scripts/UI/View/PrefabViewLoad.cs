using System;
using System.IO;
using UnityEngine;

namespace View
{
    public static class PrefabViewLoad
    {
        private static string _basePathView = "Prefabs/View/";
        
        public static GameObject LoadView(Type typeView)
        {
            string path = Path.Combine(_basePathView, typeView.Name, typeView.Name);

            GameObject view = Resources.Load<GameObject>(path);
            return view;
        }
    }
}

