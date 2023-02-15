using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResponseController : MonoBehaviour
{
    //�������Ă��邩�ǂ����ƏI��

    enum CubeColor
    {
        red = 1,
        blue,
        magenta,
        white
    };

    public int[,] mColor = new int[3, 3];
    public int[,] sColor = new int[3, 3];
    public bool[,] response = new bool[3,3]; //�������Ă��邩
    private int res = 0;                      //�����������Ă��邩

    private bool easyOr = EasyButton.easy;  //��Փx
    private int _stageCount = 0;                 //�X�e�[�W������J��Ԃ�����Q�[���I��
    private int _maxStage;                      //�P�Q�[���̃X�e�[�W�̌�
    [SerializeField] private GameObject mainCube;
    [SerializeField] private GameObject subCube;
    private GameObject main;
    private GameObject sub;
    // Start is called before the first frame update
    void Start()
    {
        if (easyOr)        //��Փx��easy�̏ꍇ��10�X�e�[�W�Ahard�Ȃ�20�X�e�[�W
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
        for(int x = 0;x <= 2; x++) {         //3*3�̃L���[�u�Ő������Ă���̂�T��
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
