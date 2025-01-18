using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Cloud类用于控制UI元素的持续向下移动，并在移出屏幕时重置其位置。
/// </summary>
public class Cloud : MonoBehaviour
{
    /// <summary>
    /// 移动速度。
    /// </summary>
    private float speed = 2.0f;

    /// <summary>
    /// 屏幕底部的Y坐标。
    /// </summary>
    private float screenBottomY;

    /// <summary>
    /// 屏幕顶部的Y坐标。
    /// </summary>
    private float screenTopY;

    private RectTransform rectTransform;

    void Start()
    {
        // 获取RectTransform组件
        rectTransform = GetComponent<RectTransform>();

        // 计算屏幕底部和顶部的Y坐标
        screenBottomY = 0;
        screenTopY = Screen.height;


        speed = Random.Range(100, 200);
    }

    void Update()
    {
        // 向下移动
        rectTransform.anchoredPosition += Vector2.down * speed * Time.deltaTime;

        // 如果移出屏幕底部，则重置到屏幕顶部
        if (rectTransform.anchoredPosition.y < screenBottomY - 100)
        {
            Vector2 newPosition = rectTransform.anchoredPosition;
            newPosition.y = screenTopY;
            rectTransform.anchoredPosition = newPosition + new Vector2(0, 300);
        }
    }
}
