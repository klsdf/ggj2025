using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
[RequireComponent(typeof(BoxCollider2D))]
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
            AudioController.Instance.PlayLaugh();



            DoSpecialAction();
            // Debug.Log(result);
        }
        else
        {
            Debug.Log("没有找到原因状态："+reason);
        }

    }

    


    public GameObject artGallery;
    public GameObject leftEye;
    public GameObject rightEye;
    public GameObject oldMan;


    public GameObject cityFly;


    public FirstEffect firstEffect;

    private void DoSpecialAction()
    {       

        switch (result)
        {
            case "艺术家是气泡":
                Debug.Log("艺术馆的墙打开了");
                artGallery.GetComponent<BoxCollider2D>().enabled = true;
               

                break;

            case "艺术馆是气泡":
                // Debug.Log("城市飞起来了");
                // cityFly.SetActive(true);
                 firstEffect.StartEffect();
                break;
            case "左边的眼泪是气泡":
                Debug.Log("左边的眼泪是气泡");
                leftEye.transform.DORotate(new Vector3(0, 0, -20), 1f);

                break;
            case "右边的眼泪是气泡":
                Debug.Log("右边的眼泪是气泡");
                rightEye.transform.DORotate(new Vector3(0, 0, 30), 1f);
                break;
            case "脸上的苹果是气泡":
                Debug.Log("脸上的苹果是气泡");
                oldMan.SetActive(true);
                break;
            case "死亡是气泡":
                Debug.Log("死亡是气泡");
                cityFly.GetComponent<BoxCollider2D>().enabled = true;
                break;
            default:
                Debug.Log("执行默认动作" + gameObject.name);
                break;
        }
    }
}

