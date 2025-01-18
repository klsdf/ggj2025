using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
/// <summary>
/// 这个类用于控制UI对象在鼠标进入和离开时的显示和隐藏。
/// </summary>
public class PhongArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject phong; // 需要显示或隐藏的UI对象
    public Vector3 enterPosition; // 鼠标进入时的目标位置
    public Vector3 exitPosition;  // 鼠标离开时的目标位置

    private void Start()
    {
        if (phong != null)
        {
            // phong.SetActive(false); // 默认隐藏UI对象
        }
        enterPosition = phong.transform.localPosition + new Vector3(0, 1300, 0);
        exitPosition = phong.transform.localPosition;
    }

    /// <summary>
    /// 当鼠标进入UI元素时，移动UI对象到指定位置。
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (phong != null)
        {
            // 停止当前的动画
            phong.transform.DOKill();
            phong.transform.DOLocalMove(enterPosition, 0.5f);
        }
    }

    /// <summary>
    /// 当鼠标离开UI元素时，移动UI对象到指定位置。
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (phong != null)
        {
            // 停止当前的动画
            phong.transform.DOKill();
            phong.transform.DOLocalMove(exitPosition, 0.5f);
        }
    }
}

