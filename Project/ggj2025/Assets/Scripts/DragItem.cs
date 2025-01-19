using UnityEngine;

/// <summary>
/// 气泡本体
/// </summary>
public class DragItem : MonoBehaviour
{
    private Vector3 offset; // 鼠标与物体之间的偏移量
    private Camera mainCamera; // 主摄像机
    public float snapDistance = 1.0f; // 距离阈值
    private bool isAttached = false; // 是否已附加子物体
    private float destroyTimer = 0.0f; // 销毁计时器


    private float speed = 1.0f;



    public GameObject 爆炸效果;

    void Start()
    {
        // 获取主摄像机
        mainCamera = Camera.main;
        // 获取 TargetItem 的引用
        // targetItem = GameObject.FindObjectOfType<TargetItem>().gameObject;
    }



    private float lifeTime = 2.0f;

    void Update()
    {
        // if (isAttached)
        // {
            // 持续向上移动
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            // 更新计时器
            destroyTimer += Time.deltaTime;
            // 10秒后销毁物体
            if (destroyTimer >= lifeTime)
            {
                // 销毁物体
                Destroy(gameObject);
                // 播放爆炸音效
                AudioController.Instance.PlayBubbleExplosion();
                // 生成爆炸效果
                Instantiate(爆炸效果, transform.position, Quaternion.identity);
            }
        // }
    }

    void OnMouseDown()
    {
        if (isAttached) return; // 禁用拖动功能
        // 计算鼠标与物体之间的偏移量
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        if (isAttached) return; // 禁用拖动功能
        // 更新物体位置
        // transform.position = GetMouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        if (isAttached) return; // 禁用拖动功能
        // 使用圆形范围检测2D
        // Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, snapDistance);
        // foreach (var hit in hits)
        // {
        //     if (hit.gameObject.GetComponent<TargetItem>())
        //     {
        //         // 将 TargetItem 设为子物体
        //         hit.gameObject.transform.SetParent(transform);
        //         print("TargetItem 已成为子物体");
        //         GameController.Instance.FindMeme(true);
        //         AudioController.Instance.PlayLaugh();

        //         break; // 只处理一个目标物体
        //     }
        // }

        // // 只要玩家松手，就标记为已附加
        // isAttached = true;
        // GameController.Instance.FindMeme(false);
    }

    /// <summary>
    /// 获取鼠标在世界坐标系中的位置
    /// </summary>
    /// <returns>鼠标的世界坐标</returns>
    private Vector3 GetMouseWorldPosition()
    {
        // 获取鼠标屏幕坐标
        Vector3 mouseScreenPosition = Input.mousePosition;
        // 将鼠标屏幕坐标转换为世界坐标
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
