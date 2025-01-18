
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;


public class LevelData
{
    public int bubbleNum;
    public int targetMeMeNum;
}





public class GameController : Singleton<GameController>
{
    // public GameObject targetItem; // 目标物体

    public TMP_Text bubbleNumText; // 气泡数量文本
    public TMP_Text targetMeMeNumText; // 目标气泡数量文本

    private int currentBubbleNum = 0; // 当前气泡数量
    private int currentMeMeNum = 0; // 当前meme数量


    public List<LevelData> levelDatas = new List<LevelData>()
    {
        new LevelData() { bubbleNum = 2, targetMeMeNum = 1 },//1
        new LevelData() { bubbleNum = 3, targetMeMeNum = 2 },//2
        new LevelData() { bubbleNum = 4, targetMeMeNum = 3 },//3
        new LevelData() { bubbleNum = 5, targetMeMeNum = 4 },//4
        new LevelData() { bubbleNum = 5, targetMeMeNum = 5 },//5
    };

    [SerializeField]
    private int currentLevel = -1;


    public GameObject bubblePrefab;

    public Button nextButton;

    private void EnterNextLevel()
    {
        currentLevel++;

        LevelData levelData = levelDatas[currentLevel];
        print($"level: {currentLevel}，levelData.bubbleNum: {levelData.bubbleNum}，levelData.targetMeMeNum: {levelData.targetMeMeNum}");
        Init(levelData);
        LevelController.Instance.LoadLevel(currentLevel);
        // SceneController.Instance.ActivateScene(SceneType.Game);
    }

    public void UpdateUI(LevelData levelData)
    {
        bubbleNumText.text = $"气泡数量: {currentBubbleNum}/{levelData.bubbleNum}";
        targetMeMeNumText.text = $"目标迷因数量: {currentMeMeNum}/{levelData.targetMeMeNum}";
    }

    private LevelData GetNowLevelData()
    {
        LevelData levelData = levelDatas[currentLevel];
        // Init(levelData);
        return levelData;
    }



    private void CreateBubble(Vector3 position)
    {
        if (currentBubbleNum <= 0) return;
        currentBubbleNum--;
        Instantiate(bubblePrefab, position, Quaternion.identity);
    }

    public void FindMeme(bool isFind)
    {
        if (isFind)
        {
            currentMeMeNum++;
        }

        if (currentMeMeNum == GetNowLevelData().targetMeMeNum)
        {
            // 游戏胜利
            Debug.Log("游戏胜利");
            return;
        }

        if (currentBubbleNum == 0)
        {
            // 游戏失败
            Debug.Log("游戏失败");
        }
    }
    private void Start()
    {
        currentLevel = -1;
        EnterNextLevel();
        nextButton.onClick.AddListener(EnterNextLevel);
    }

    private void Init(LevelData levelData)
    {
        currentBubbleNum = levelData.bubbleNum;
        currentMeMeNum = 0;
    }


    void Update()
    {
        UpdateUI(GetNowLevelData());

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            CreateBubble(mousePosition);
        }




    }
}
