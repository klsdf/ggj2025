using UnityEngine;
using DG.Tweening;
using UnityEditor.SceneManagement;
public class FirstEffect : MonoBehaviour
{

    // public GameObject city;
    public GameObject buildings;

    public GameObject clouds;
    public GameObject texts;

    public SceneTitleBubble titleBubble;

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
        buildings.transform.DOMove(buildingsInitialPosition, 10f);
        clouds.transform.DOMove(cloudsInitialPosition, 10f);
        texts.transform.DOMove(textsInitialPosition, 10f);
        titleBubble.Run();
        print("开始效果");


        AudioController.Instance.Play夜上海();
    }
}
