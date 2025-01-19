using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneObj : MonoBehaviour
{
    // public GameObject sceneObj;
    public LevelObjType targetType;

    Color originalColor;
    private void Start() {
        originalColor = GetComponent<SpriteRenderer>().color;
    }



    void OnMouseDown()
    {
        LevelController.Instance.EnterLevel(targetType);
        AudioController.Instance.PlayClick2();
        GetComponent<SpriteRenderer>().color = originalColor;
    }

    void OnMouseEnter()
    {
        // AudioController.Instance.PlayClick2();
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.84f, 0.0f); // 金色
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }

}
