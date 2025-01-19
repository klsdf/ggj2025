using TMPro;
using UnityEngine;


/// <summary>
/// 场景中出现的标题气泡
/// </summary>
public class SceneTitleBubble : MonoBehaviour
{
    private bool isStart = false;
    public float speed = 0.5f;

    private void Update() {
        if(isStart)
        {
            // transform.DOMove(transform.position + new Vector3(0, 1, 0), 1f);
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }


    public void Run()
    {
        isStart = true;
    }
}

