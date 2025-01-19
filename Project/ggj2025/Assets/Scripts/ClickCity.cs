using UnityEngine;

public class ClickCity : MonoBehaviour
{

    void OnMouseDown()
    {
        Debug.Log("城市飞起来了");
        CityFly.Instance.Fly();
    }
}
