using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public enum SceneType
{
    Start,
    Game,
    End,
    Help,
}

[System.Serializable]
public class SceneObject
{
    public SceneType type;
    public GameObject gameObject;
}

/// <summary>
/// 这个类用于动态控制场景内物体的激活状态。
/// </summary>
public class SceneController : Singleton<SceneController>
{

    public GameObject LogoPage;

    public Image backgroundToFade;

    public SceneType startSceneType;
    /// <summary>
    /// 存储所有场景对象的列表。
    /// </summary>
    [SerializeField]
    private List<SceneObject> sceneObjects = new List<SceneObject>();

    void Awake()
    {
        LogoPage.SetActive(true);
        //遍历所有对象，全部active false
        foreach (var sceneObject in sceneObjects)
        {
            sceneObject.gameObject.SetActive(false);
        }

        StartCoroutine(DelayedActivateScene(1f));
    }

    /// <summary>
    /// 协程：延迟3秒后激活场景。
    /// </summary>
    /// <returns>协程迭代器</returns>
    private IEnumerator DelayedActivateScene(float delay)
    {
        yield return new WaitForSeconds(delay); 
        ActivateScene(startSceneType);
    }

    /// <summary>
    /// 激活指定类型的场景，并将其他场景设置为不激活。
    /// </summary>
    /// <param name="sceneType">要激活的场景类型。</param>
    public void ActivateScene(SceneType sceneType)
    {
        float fadeOutTime = 1f;//2
        float fadeInTime = 1f;//3
        backgroundToFade.DOFade(1, fadeOutTime).OnComplete(() =>
          {
            LogoPage.SetActive(false);
              foreach (var sceneObject in sceneObjects)
              {

                  
                  sceneObject.gameObject.SetActive(sceneObject.type == sceneType);
              }
              backgroundToFade.DOFade(0, fadeInTime);
          });

    }

}
