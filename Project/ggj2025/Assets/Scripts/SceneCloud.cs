using UnityEngine;  

public class SceneCloud : MonoBehaviour
{
    /// <summary>
    /// 移动速度。
    /// </summary>
    public float speed = 1.0f;

    /// <summary>
    /// 计时器。
    /// </summary>
    private float timer = 0.0f;

    /// <summary>
    /// 每10秒的时间间隔。
    /// </summary>
    private float interval = 10.0f;

    void Update()
    {
        // 向左移动
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // 检查x坐标
        if (transform.position.x < -10.0f)
        {
            transform.position += Vector3.right * 20.0f;
        }
    }
}
