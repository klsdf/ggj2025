using UnityEngine;

public class SceneObj : MonoBehaviour
{
    // public GameObject sceneObj;
    public LevelObjType targetType;



    void OnMouseDown()
    {
        LevelController.Instance.EnterLevel(targetType);
        AudioController.Instance.PlayClick2();
    }

}