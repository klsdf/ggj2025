using UnityEngine;
using TMPro;

public class TextItem : MonoBehaviour
{
    public TMP_Text text;
    // private void Start()
    // {
    //     text = GetComponentInChildren<TMP_Text>();
    // }

    public void Init(string content)
    {
        text.text = content;
    }
}

