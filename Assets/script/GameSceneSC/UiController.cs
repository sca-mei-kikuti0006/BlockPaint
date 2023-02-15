using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    private static float _countTime = 0.0f; //�ʃV�[���ŎQ�Ɨp
    private float sec = 0.0f;              //textui�p(�b)
    private float minute = 0.0f;           //textui�p(��)

    [SerializeField] private Text timeText;
    [SerializeField] private Text countStageText;
    [SerializeField] private Text maxStageText;

    GameObject GameManager;
    ResponseController gmSc;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        gmSc = GameManager.GetComponent<ResponseController>();

        maxStageText.text = "/" + gmSc.maxStage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        sec += Time.deltaTime;
        _countTime += Time.deltaTime;

        if (sec >= 60.0f ) { //�����Z
            minute++;
            sec = sec - 60.0f;
            
        }

        timeText.text = minute.ToString("00") + ":" +  sec.ToString("00.00");

        countStageText.text = gmSc.stageCount.ToString("00");
    }

    //getter
    public static float countTime
    {
        get { return _countTime; }
    }
}
