using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResponseController : MonoBehaviour
{
    //正解しているかどうかと終了

    enum CubeColor
    {
        red = 1,
        blue,
        magenta,
        white
    };

    public int[,] mColor = new int[3, 3];
    public int[,] sColor = new int[3, 3];
    public bool[,] response = new bool[3,3]; //正解しているか
    private int res = 0;                      //いくつ正解しているか

    private bool easyOr = EasyButton.easy;  //難易度
    private int _stageCount = 0;                 //ステージをｎ回繰り返したらゲーム終了
    private int _maxStage;                      //１ゲームのステージの個数
    [SerializeField] private GameObject mainCube;
    [SerializeField] private GameObject subCube;
    private GameObject main;
    private GameObject sub;
    // Start is called before the first frame update
    void Start()
    {
        if (easyOr)        //難易度がeasyの場合は10ステージ、hardなら20ステージ
        {
            _maxStage = 10;
        }else {
            _maxStage = 20;
        }
        NewStage();
    }

    // Update is called once per frame
    void Update()
    {
        for(int x = 0;x <= 2; x++) {         //3*3のキューブで正解しているのを探す
            for(int y = 0;y <= 2;y++){
                if (mColor[x,y] == sColor[x, y]) { 
                    response[x,y] = true;
                    res++;
                } else {
                    response[x, y] = false;
                }
            }
        }

        if(res == 9) {
            _stageCount++;
            Destroy(main);
            Destroy(sub);

            if (_stageCount == _maxStage) {
                SceneManager.LoadScene("ClearScene");
            }

            NewStage();
        }

        res = 0;
    }

    void NewStage() {
        main = Instantiate(mainCube);
        sub = Instantiate(subCube);
    }

    public int stageCount
    {
        get { return this._stageCount; }
    }
    public int maxStage
    {
        get { return this._maxStage; }
    }

}
