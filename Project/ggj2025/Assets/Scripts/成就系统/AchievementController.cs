using UnityEngine;
using Sirenix.OdinInspector;

public class AchievementController : Singleton<AchievementController>
{
    public GameObject achievementPrefab;


    public GameObject parent;



    [Button("Test")]

    public void Test()
    {
        SendAchievement("Test");
    }

    public void SendAchievement(string content)
    {
        GameObject achievement = Instantiate(achievementPrefab, parent.transform);
        achievement.GetComponent<AchievementPrefab>().Init(content);
    }
}
