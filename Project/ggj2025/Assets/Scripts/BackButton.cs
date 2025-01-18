using UnityEngine;
using TMPro;
public class BackButton : MonoBehaviour
{
    public LevelObjType targetType;
    private SpriteRenderer spriteRenderer;

    public TMP_Text text;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSpriteAlpha(0f); // 默认透明度为0
        // text = GetComponentInChildren<TMP_Text>();
        text.gameObject.SetActive(false);
    }

    /// <summary>
    /// 当鼠标点击时，进入指定的关卡。
    /// </summary>
    void OnMouseDown()
    {
        LevelController.Instance.EnterLevel(targetType);
        AudioController.Instance.PlayClick2();
    }

    /// <summary>
    /// 当鼠标进入时，将透明度设置为1。
    /// </summary>
    void OnMouseEnter()
    {
        SetSpriteAlpha(1f);
        text.gameObject.SetActive(true);
    }

    /// <summary>
    /// 当鼠标离开时，将透明度设置为0。
    /// </summary>
    void OnMouseExit()
    {
        SetSpriteAlpha(0f);
        text.gameObject.SetActive(false);
    }

    /// <summary>
    /// 设置精灵的透明度。
    /// </summary>
    /// <param name="alpha">透明度值，范围从0到1。</param>
    private void SetSpriteAlpha(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}
