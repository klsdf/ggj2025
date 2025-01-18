using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;


public class LevelData
{
    public int bubbleNum;
    public int targetMeMeNum;


    public string wikiText;
}





public class GameController : Singleton<GameController>
{
    // public GameObject targetItem; // 目标物体

    // public TMP_Text bubbleNumText; // 气泡数量文本
    // public TMP_Text targetMeMeNumText; // 目标气泡数量文本

    // private int currentBubbleNum = 0; // 当前气泡数量
    // private int currentMeMeNum = 0; // 当前meme数量



    public TMP_Text WikiText;//介绍的文本


    public List<LevelData> levelDatas = new List<LevelData>()
    {
        new LevelData() { bubbleNum = 2, targetMeMeNum = 1,
wikiText = @"气泡迷因：
一种新兴的迷因，气泡本身的含义指代肥皂泡、文本框、虚幻飘渺的事物等。
不过近来一些新兴的艺术家很热衷于用气泡创作一些实验艺术，例如将气泡P在传统名画上，让其得到了一定范围的传播" },//1
        new LevelData() { bubbleNum = 3, targetMeMeNum = 2,
wikiText = @"气泡迷因：
一种新兴的迷因，气泡本身的含义指代肥皂泡、文本框、虚幻飘渺的事物等。
不过近来一些新兴的艺术家很热衷于用气泡创作一些实验艺术，例如将气泡P在传统名画上，让其得到了一定范围的传播。

前几日，因为艺术家bubble的新作品，让作品得到了广泛传播。气泡迷因也在逐渐流行起来。" 
},//2
        new LevelData() { bubbleNum = 4, targetMeMeNum = 3,
wikiText = @"气泡迷因：
" },//3
        new LevelData() { bubbleNum = 5, targetMeMeNum = 4,
wikiText = @"气泡迷因：
" },//4
        new LevelData() { bubbleNum = 5, targetMeMeNum = 5,
wikiText = @"气泡迷因：
" },//5
    };




    public GameObject bubblePrefab;

    public Button nextButton;


    public void UpdateUI(LevelData levelData)
    {
        // bubbleNumText.text = $"气泡数量: {currentBubbleNum}/{levelData.bubbleNum}";
        // targetMeMeNumText.text = $"目标迷因数量: {currentMeMeNum}/{levelData.targetMeMeNum}";
    }

    // private LevelData GetNowLevelData()
    // {
    //     LevelData levelData = levelDatas[currentLevel];
    //     // Init(levelData);
    //     return levelData;
    // }



    /// <summary>
    /// 创建气泡
    /// </summary>
    /// <param name="position">气泡位置</param>
    /// <returns>气泡对象</returns>
    public GameObject CreateBubble(Vector3 position)
    {
        // if (currentBubbleNum <= 0) return;
        // currentBubbleNum--;
        GameObject bubble = Instantiate(bubblePrefab, position, Quaternion.identity);
        // transform.SetParent(bubble.transform);
        // print("TargetItem 已成为子物体");
        // FindMeme(true);
        // AudioController.Instance.PlayLaugh();
        return bubble;
    }

    public void FindMeme(bool isFind)
    {
        // if (isFind)
        // {
        //     currentMeMeNum++;
        // }

        // if (currentMeMeNum == GetNowLevelData().targetMeMeNum)
        // {
        //     // 游戏胜利
        //     Debug.Log("游戏胜利");
        //     return;
        // }

        // if (currentBubbleNum == 0)
        // {
        //     // 游戏失败
        //     Debug.Log("游戏失败");
        // }
    }
    private void Start()
    {
        // currentLevel = -1;
        // EnterNextLevel();
        // nextButton.onClick.AddListener(EnterNextLevel);

        // WikiText.text = GetNowLevelData().wikiText;

    }

    // private void Init(LevelData levelData)
    // {
    //     currentBubbleNum = levelData.bubbleNum;
    //     currentMeMeNum = 0;
    // }


    void Update()
    {
        // UpdateUI(GetNowLevelData());

        // if (Input.GetMouseButtonDown(1))
        // {
        //     Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     mousePosition.z = 0;
        //     CreateBubble(mousePosition);
        // }




    }
}
