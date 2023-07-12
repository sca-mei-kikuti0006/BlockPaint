using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private static float[] time = new float[5];
    private float compareTime = UiController.countTime;
    private float emptyTime;

    [SerializeField] private Text timeText;     //clearSceneÇ»ÇÁclearTime,startSceneÇ»ÇÁÇQÅ`ÇSà 
    [SerializeField] private Text bestTimeText;

    private float clearTime = UiController.countTime;
    private float minute;
    private float sec;
    private string[] renk = new string[4];

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "ClearScene")//clearScene
        {
            for (int i = 0; i < 5; i++)
            { //àÍà Ç©ÇÁå‹à Ç‹Ç≈ÇåàÇﬂÇÈ
                if (time[i] > compareTime)
                {
                    emptyTime = time[i];
                    time[i] = compareTime;
                    compareTime = emptyTime;
                }
                else if (time[i] == 0) {
                    time[i] = compareTime;
                    break;
                }
            }
            ClearSceneText();
        }
        else { //startScene
            StartSceneText();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ClearSceneText() {
        Conversion(clearTime);
        timeText.text = minute.ToString("00") + ":" + sec.ToString("00.00");
        Conversion(time[0]);
        bestTimeText.text = minute.ToString("00") + ":" + sec.ToString("00.00");
    }

    private void StartSceneText()
    {
        timeText.text = "";
        for (int i = 1; i < 5; i++) {
            Debug.Log(i);
            Debug.Log(time[i]);
            Conversion(time[i]);
            timeText.text += minute.ToString("00") + ":" + sec.ToString("00.00") + "\n";
            Debug.Log(sec);
        }
        Conversion(time[0]);
        bestTimeText.text = minute.ToString("00") + ":" + sec.ToString("00.00");
    }

    private void Conversion(float time)
    {
        minute = time / 60;
        sec = time % 60;
    }

}
