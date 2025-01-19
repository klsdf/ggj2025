using UnityEngine;
using TMPro;
public class MoveDownText : MonoBehaviour
{
    public TMP_Text text;
    private float speed = 0.5f;
    public void Start()
    {
        // transform.DOLocalMove(new Vector3(0, -10, 0), 5f);
    }


    public void Init(string content)
    {
        text.text = content;
    }
    public void Update()
    {
        transform.position += Vector3.down * speed*Time.deltaTime;


        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
