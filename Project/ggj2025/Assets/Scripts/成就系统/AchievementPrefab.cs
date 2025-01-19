using UnityEngine;  
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;

public class AchievementPrefab : MonoBehaviour
{
    public TMP_Text achievementText;



    // void Awake()
    // {
    //     // Test();
    //     achievementText = GetComponent<TMP_Text>();
    // }

    public void Init(string content)
    {
        achievementText.text = content;
        // 开始从上到下移动
        transform.DOMoveY(-Screen.height, 1f).From().OnComplete(() =>
        {
            // 3秒后移动到上方并消失
            DOVirtual.DelayedCall(3f, () =>
            {
                transform.DOMoveY(Screen.height, 1f).OnComplete(() =>
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject);
                });
            });
        });
    }
}   

