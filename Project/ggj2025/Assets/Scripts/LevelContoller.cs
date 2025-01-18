using System.Collections.Generic;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    public List<GameObject> levelObjList;

    public void LoadLevel(int level)
    {
        for (int i = 0; i < levelObjList.Count; i++)
        {
            levelObjList[i].SetActive(i == level);
        }
    }
}