using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCubeController : MonoBehaviour
{
    private Material material;
    private MeshRenderer emi;

    private int sPosX;
    private int sPosY;

    GameObject GameManager;
    ResponseController gmSc;

    //マウスクリックしたか
    private bool inputR = false;
    private bool inputB = false;
    private bool inputW = false;

    [SerializeField]private Material redMate;
    [SerializeField] private Material blueMate;
    [SerializeField] private Material magentaMate;

    private bool easyOr = EasyButton.easy;//難易度

    enum CubeColor
    {
        red = 1,
        blue,
        magenta,
        white
    };
    private CubeColor color = CubeColor.white;
    // Start is called before the first frame update
    void Start()
    {
        material = this.GetComponent<Renderer>().material;

        emi = GetComponent<MeshRenderer>();
        emi.material.EnableKeyword("_EMISSION");

        //座標
        //x
        if (transform.position.x == 10) sPosX = 0;
        else if (transform.position.x >= 8) sPosX = 1;
        else sPosX = 2;
        //y
        if (transform.position.y == 0) sPosY = 0;
        else if (transform.position.y >= -1.05) sPosY = 1;
        else sPosY = 2;

        GameManager = GameObject.Find("GameManager");
        gmSc = GameManager.GetComponent<ResponseController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))     //左クリックは赤
        {
            inputR  = true;
        }
        else if (Input.GetKey(KeyCode.Mouse1))//右クリックは青
        {
            inputB = true;
        }
        else if (Input.GetKey(KeyCode.Mouse2))//マウスホイールは白
        {
            inputW = true;
        }
        else {
            inputR = false;
            inputB = false;
            inputW = false;
        }


        //cubeの色
        if(material.color == Color.red) color = CubeColor.red;
        else if (material.color == Color.blue) color = CubeColor.blue;
        else if (material.color == Color.magenta) color = CubeColor.magenta;
        else  color = CubeColor.white;


        //正解しているか確認用のGameManagerに情報を送る
        gmSc.sColor[sPosX, sPosY] = (int)color;

        luminescence();//正解していたら発光する
    }

    //色を変える関数
    public void OnClickObject() {
        if(inputR  == true) {                     //左クリックしたとき
            if(material.color == Color.blue)      //cubeが青だったときは紫にする
            {
                material.color = Color.magenta;
            }
            else if(material.color == Color.white)//cubeが白だったときは赤にする
            {
                material.color = Color.red;
            }
        }
        else if (inputB == true){                 //右クリックしたとき
            if (material.color == Color.red)      //cubeが赤だったときは紫にする
            {
                material.color = Color.magenta;
            }
            else if(material.color == Color.white)//cubeが白だったときは青にする
            {
                material.color = Color.blue;
            }
        }
        else if (inputW == true)                  //マウスホイールをクリックしたとき白にする
        {
            material.color = Color.white;
            emi.material.SetColor("_EmissionColor", new Color(0.0f,0.0f,0.0f,0.0f));
        }
        
    }

    void luminescence(){//正解していたら発光する
        if (gmSc.response[sPosX, sPosY] == true)
        {
            if (material.color != Color.white)
            {
                emi.material.SetColor("_EmissionColor", material.color);
            }
        }
        else
        {
            emi.material.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f, 0.0f));
        }
    }
}
