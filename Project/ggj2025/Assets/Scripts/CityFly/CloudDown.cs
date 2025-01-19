using UnityEngine;  
using DG.Tweening;

public class CloudDown : MonoBehaviour
{
    private Vector3 originalPosition;

    void Start()
    {
        // 记录初始位置
        originalPosition = transform.position;

        // 获取RectTransform组件
        // rectTransform = GetComponent<RectTransform>();
        speed = Random.Range(5, 10);

        // float scale = Random.Range(0.1f, 3f);

        // transform.localScale = new Vector3(scale, scale, scale);
    }
    /// <summary>
    /// 移动速度。
    /// </summary>
    private float speed = 1.0f;

    void Update()
    {
        // 向下移动
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 检查y坐标
        if (transform.position.y < -10.0f)
        {
            // 使用DOTween平滑移动回原始位置
            // transform.DOMove(originalPosition, 1.0f);
            transform.position = originalPosition;
        }
    }
}
