using UnityEngine;

public class ChangeableItem : MonoBehaviour
{

    public Sprite[] sprites;

    private int currentIndex = 0;


    private SpriteRenderer spriteRenderer;
    private void Start() {
        changeTime = Random.Range(0.5f, 1.5f);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    float changeTime ;
    float timer = 0f;
    private void Update() {
        timer += Time.deltaTime;
        if (timer > changeTime) {
            Change();
            timer = 0;
        }
    }

    public void Change()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[currentIndex];
        currentIndex++;
        if (currentIndex >= sprites.Length) {
            currentIndex = 0;
        }
    }
}
