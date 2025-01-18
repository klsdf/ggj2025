using UnityEngine;

/// <summary>
/// 物品控制器，用于在随机屏幕坐标生成UI元素
/// </summary>
public class ItemController : Singleton<ItemController>
{
    // UI 预制体
    public GameObject uiPrefab;

    // UI 父对象（通常是Canvas）
    public RectTransform uiParent;

    // 在游戏开始时调用一次
    void Start()
    {
        if (uiPrefab == null)
        {
            Debug.LogError("UI预制体未设置！");
            return;
        }

        if (uiParent == null)
        {
            Debug.LogError("UI父对象未设置！");
            return;
        }

        // 初始生成一个UI元素
        SpawnUIElementAtRandomPosition();
    }

    /// <summary>
    /// 在随机屏幕坐标生成UI元素
    /// </summary>
    /// 【
    public void SpawnUIElementAtRandomPosition()
    {
        // 获取屏幕尺寸
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // 生成随机屏幕坐标
        float randomX = Random.Range(0, screenWidth);
        float randomY = Random.Range(0, screenHeight);

        // 将屏幕坐标转换为UI坐标
        Vector2 uiPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(uiParent, new Vector2(randomX, randomY), null, out uiPosition);

        // 实例化UI元素
        GameObject uiElement = Instantiate(uiPrefab, uiParent);
        uiElement.GetComponent<RectTransform>().anchoredPosition = uiPosition;
    }
}
