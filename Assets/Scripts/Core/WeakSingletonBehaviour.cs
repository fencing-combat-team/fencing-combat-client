using System;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// �����ࣨMonoBehavior)
    /// </summary>
    /// <typeparam name="T">�Լ�������</typeparam>
    public class WeakSingletonBehaviour<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        private static T _instance;

        private static object _lock = new object();
        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogWarning($"��������{typeof(T)}�Ѿ����٣�����null");
                    return null;
                }

                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = FindObjectOfType<T>();
                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = "(WeakSingleton) " + typeof(T).ToString();
                        }
                    }
                }
                return _instance;
            }
        }

        private static bool applicationIsQuitting = false;

        void OnDestroy()
        {
            _instance = null;
            applicationIsQuitting = true;
        }
        void OnApplicationQuit()
        {
            _instance = null;
            applicationIsQuitting = true;
        }
    }
}
