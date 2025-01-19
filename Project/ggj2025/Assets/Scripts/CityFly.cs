using UnityEngine;
using DG.Tweening;
using System.Collections;
using Sirenix.OdinInspector;
public class CityFly : MonoBehaviour
{
    // public GameObject city;
    // public GameObject other;
    public GameObject bubble;

    public GameObject clouds;

    public GameObject texts;


    public GameObject[] moveDownClouds;

    public GameObject moveDownTextPrefab;
    

    
    [Button("飞起来")]
    private void Fly()
    {
        bubble.transform.DOLocalMove(new Vector3(6, 0, 0), 5f).OnComplete(() => {
            bubble.GetComponent<SpriteRenderer>().sortingOrder = 109;
        });
        clouds.transform.DOLocalMove(new Vector3(0, -10, 0), 5f).OnComplete(() => {
            // foreach (Transform child in clouds.transform)
            // {
            //     child.gameObject.SetActive(true);
            // }
        });
        texts.transform.DOLocalMove(new Vector3(0, -10, 0), 5f);
        foreach (var cloud in moveDownClouds)
        {
            cloud.SetActive(true);
        }
        StartCoroutine(EndEffect());
    }


    IEnumerator EndEffect()
    {
        yield return new WaitForSeconds(5f);
        float randomX = 0f;
        GameObject temp;
        // float randomY = Random.Range(-10, 10);
         temp = Instantiate(moveDownTextPrefab, new Vector3(randomX, 10, 0), Quaternion.identity);
        temp.GetComponent<MoveDownText>().Init("于是，这座城市和气泡一起漂浮起来");


        yield return new WaitForSeconds(5f);
        temp = Instantiate(moveDownTextPrefab, new Vector3(randomX, 10, 0), Quaternion.identity);

        temp.GetComponent<MoveDownText>().Init("直到这个宇宙本身也变成气泡的一部分");

        yield return new WaitForSeconds(5f);
        temp = Instantiate(moveDownTextPrefab, new Vector3(randomX, 10, 0), Quaternion.identity);
        temp.GetComponent<MoveDownText>().Init("或者");

        yield return new WaitForSeconds(5f);
        temp = Instantiate(moveDownTextPrefab, new Vector3(randomX, 10, 0), Quaternion.identity);
        temp.GetComponent<MoveDownText>().Init("在它飞向天空之前，它就会带着人类的一起飘走的回忆");

        yield return new WaitForSeconds(5f);
        temp = Instantiate(moveDownTextPrefab, new Vector3(randomX, 10, 0), Quaternion.identity);
        temp.GetComponent<MoveDownText>().Init("轻轻的，不经意地炸开。");

        yield return new WaitForSeconds(5f);
        temp = Instantiate(moveDownTextPrefab, new Vector3(randomX, 10, 0), Quaternion.identity);
        temp.GetComponent<MoveDownText>().Init("制作组：帽子社");

        yield return new WaitForSeconds(15f);

        SceneController.Instance.ActivateScene(SceneType.Start);

    }


    void OnMouseDown()
    {
        Debug.Log("城市飞起来了");
        Fly();
    }
}
