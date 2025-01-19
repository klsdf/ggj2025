using UnityEngine;
using DG.Tweening;
public class FirstEffect : MonoBehaviour
{

    public GameObject city;
    public GameObject buildings;

    public GameObject clouds;
    public GameObject texts;

    private Vector3 buildingsInitialPosition;
    private Vector3 cloudsInitialPosition;
    private Vector3 textsInitialPosition;

    private void Start() {
        Init();
    }

    void Init()
    {
        buildingsInitialPosition = buildings.transform.position;
        cloudsInitialPosition = clouds.transform.position;
        textsInitialPosition = texts.transform.position;
        buildings.SetActive(true);
        clouds.SetActive(true);
        texts.SetActive(true);
        buildings.transform.position += new Vector3(0, -10, 0);
        clouds.transform.position += new Vector3(0, 10, 0);
        texts.transform.position += new Vector3(0, 10, 0);
    }
    public void StartEffect()
    {
        buildings.transform.DOMove(buildingsInitialPosition, 5f);
        clouds.transform.DOMove(cloudsInitialPosition, 5f);
        texts.transform.DOMove(textsInitialPosition, 5f);
        print("开始效果");
    }
}
