
using UnityEngine;
using TMPro;
public class GameController : Singleton<GameController>
{
    // public GameObject targetItem; // 目标物体

    public TMP_Text bubbleNumText; // 气泡数量文本
    public TMP_Text targetMeMeNumText; // 目标气泡数量文本

    private int bubbleNum = 1; // 气泡数量
    private int currentBubbleNum = 0; // 当前气泡数量

    private int targetMeMeNum = 1; // 目标气泡数量
    private int currentMeMeNum = 0; // 当前meme数量


    public void FindMeme(bool isFind)
    {
        if (isFind)
        {
            currentMeMeNum++;
        }
        bubbleNum--;


        if (currentMeMeNum == targetMeMeNum)
        {
            // 游戏胜利
            Debug.Log("游戏胜利");
            return;
        }

        if (bubbleNum == 0)
        {
            // 游戏失败
            Debug.Log("游戏失败");
        }
    }

    public void Init()
    {
        bubbleNum = 1;
        currentBubbleNum = bubbleNum;

        targetMeMeNum = 1;
        currentMeMeNum = 0;
    }


    void Update()
    {
        bubbleNumText.text = $"气泡数量: {currentBubbleNum}/{bubbleNum}";
        targetMeMeNumText.text = $"目标气泡数量: {currentMeMeNum}/{targetMeMeNum}";
    }
}
