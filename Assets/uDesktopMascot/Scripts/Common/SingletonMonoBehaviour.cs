using Unity.Logging;
using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    ///     シーンにまたがってデータを保持するクラスのベースクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        ///     シングルトンのインスタンス
        /// </summary>
        private static T _instance;

        /// <summary>
        ///     シングルトンのインスタンス
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();
                    if (_instance == null)
                    {
                        Log.Warning(typeof(T) + "SingletonMonoBehaviour is nothing");
                    } else
                    {
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                }

                return _instance;
            }
        }

        private protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            } else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}