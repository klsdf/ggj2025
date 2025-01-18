using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 这个类用于控制UI对象在鼠标进入和离开时的显示和隐藏。
/// </summary>
public class PhongArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject phong; // 需要显示或隐藏的UI对象

    private void Start()
    {
        if (phong != null)
        {
            phong.SetActive(false); // 默认隐藏UI对象
        }
    }

    /// <summary>
    /// 当鼠标进入UI元素时，显示UI对象。
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (phong != null)
        {
            phong.SetActive(true);
        }
    }

    /// <summary>
    /// 当鼠标离开UI元素时，隐藏UI对象。
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (phong != null)
        {
            phong.SetActive(false);
        }
    }
}

