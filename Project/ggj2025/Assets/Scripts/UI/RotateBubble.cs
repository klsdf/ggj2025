using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

/// <summary>
/// RotateBubble 类用于实现 UI 图片的缓慢顺时针旋转。
/// </summary>
public class RotateBubble : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public float rotationSpeed = 10.0f; // 旋转速度

    void Update()
    {
        // 每帧更新旋转角度
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
    }
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        // 鼠标滑入时，父物体缩放至1.3倍
        transform.parent.DOScale(1.1f, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 鼠标滑出时，父物体恢复正常大小
        transform.parent.DOScale(1.0f, 0.5f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        SceneController.Instance.ActivateScene(SceneType.Game);
    }
}
