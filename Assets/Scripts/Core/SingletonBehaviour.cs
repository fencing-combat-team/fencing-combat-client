using UnityEngine;

namespace Core
{
    /// <summary>
    /// 单例类（MonoBehavior)
    /// </summary>
    /// <typeparam name="T">自己的类型</typeparam>
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
                    Debug.LogWarning($"单例对象：{typeof(T)}已经销毁，返回null");
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
