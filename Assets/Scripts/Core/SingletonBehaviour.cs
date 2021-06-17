using UnityEngine;

namespace Core
{
    /// <summary>
    /// �����ࣨMonoBehavior)
    /// </summary>
    /// <typeparam name="T">�Լ�������</typeparam>
    public class SingletonBehaviour<T> : MonoBehaviour
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
                            singleton.name = "(Singleton) " + typeof(T).ToString();
                            DontDestroyOnLoad(singleton);
                        }
                    }
                }
                return _instance;
            }
        }

        private static bool applicationIsQuitting = false;

        void OnDestroy()
        {
            applicationIsQuitting = true;
        }
        void OnApplicationQuit()
        {
            applicationIsQuitting = true;
        }
    }
}
