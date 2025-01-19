using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public enum LevelObjType
{
    美术馆,
    达利,
    珍珠耳环的少女,
    伊凡杀子,
    大地图,
    浴室,
    浴缸,
    办公室,
    白板,
    电脑,
    教室,
    考试卷,
    

}


[System.Serializable]
public class LevelObj
{
    public GameObject levelObj;
    public LevelObjType type;
}


public class LevelController : Singleton<LevelController>
{

    public List<LevelObj> levelObjList;

        [SerializeField]
    private int currentLevel = -1;


    public Button nextButton;
    public Button prevButton;

    // private int maxLevel = 0;

    public void LoadLevel(int level)
    {
        for (int i = 0; i < levelObjList.Count; i++)
        {
            levelObjList[i].levelObj.SetActive(i == level);
        }
    }

    private void Start()
    {
        EnterNextLevel();
        nextButton.onClick.AddListener(EnterNextLevel);
        prevButton.onClick.AddListener(ExitCurrentLevel);
    }

    public void EnterLevel(LevelObjType type)
    {
        for (int i = 0; i < levelObjList.Count; i++)
        {
            levelObjList[i].levelObj.SetActive(levelObjList[i].type == type);
        }
    }

    private void EnterNextLevel()
    {
        currentLevel++;
        if (currentLevel >= levelObjList.Count)
        {
            currentLevel = levelObjList.Count - 1;
        }


        // LevelData levelData = levelDatas[currentLevel];
        // print($"level: {currentLevel}，levelData.bubbleNum: {levelData.bubbleNum}，levelData.targetMeMeNum: {levelData.targetMeMeNum}");
        // Init(levelData);
        Instance.LoadLevel(currentLevel);
        AudioController.Instance.PlayClick2();
        // SceneController.Instance.ActivateScene(SceneType.Game);
    }

    private void ExitCurrentLevel()
    {
        currentLevel--;
        if (currentLevel < 0)
        {
            currentLevel = 0;
        }
        Instance.LoadLevel(currentLevel);
        AudioController.Instance.PlayClick2();
    }

    [Button("隐藏所有场景")]
    public void HideAllLevel()
    {
        for (int i = 0; i < levelObjList.Count; i++)
        {
            levelObjList[i].levelObj.SetActive(false);
        }
    }
}