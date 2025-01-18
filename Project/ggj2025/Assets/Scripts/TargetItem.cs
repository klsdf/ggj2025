using UnityEngine;
using UnityEngine.EventSystems;

public class TargetItem : MonoBehaviour
{
    // public GameObject targetItem; // 目标物体
    public string reason;
    public string result;

    public void OnMouseDown()
    {

        if (RuleController.Instance.isHasState(reason))
        {
            // result = RuleController.Instance.GetResultByReason(reason);
            RuleController.Instance.AddState(reason, result);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            GameObject bubble = GameController.Instance.CreateBubble(mousePosition);
            transform.SetParent(bubble.transform);
            AudioController.Instance.PlayClick();



            DoSpecialAction();
            // Debug.Log(result);
        }
        else
        {
            Debug.Log("没有找到原因");
        }

    }



    private void DoSpecialAction()
    {       

        switch (gameObject.name)
        {
            // case "苹果是气泡":
            //     Debug.Log("执行特殊动作");
            //     break;
            default:
                Debug.Log("执行默认动作" + gameObject.name);
                break;
        }
    }
}

