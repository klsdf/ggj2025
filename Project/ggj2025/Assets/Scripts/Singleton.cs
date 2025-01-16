using UnityEngine;

/// <summary>
/// 单例基类，用于确保每个继承的类只有一个实例。
/// </summary>
/// <typeparam name="T">继承单例的类类型。</typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// 单例实例。
    /// </summary>
    private static T _instance;

    /// <summary>
    /// 获取单例实例。
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// 确保单例在场景切换时不被销毁。
    /// </summary>
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
} 