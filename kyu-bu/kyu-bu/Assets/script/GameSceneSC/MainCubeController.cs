using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCubeController : MonoBehaviour
{
   enum CubeColor { 
        red = 1,
        blue,
        magenta,
        white
   };

    private CubeColor cubeColor;

    private int mPosX;
    private int mPosY;

    private MeshRenderer emi;
    GameObject GameManager;
    ResponseController gmSc;

    // Start is called before the first frame update
    void Start()
    {
        //色決め
        Material material = this.GetComponent<Renderer>().material;

        emi = GetComponent<MeshRenderer>();
        emi.material.EnableKeyword("_EMISSION");

        int random = Random.Range(1,5);
        cubeColor = (CubeColor)random;
        switch (cubeColor) { 
            case CubeColor.red:
                material.color = Color.red;
                break;
            case CubeColor.blue:
                material.color = Color.blue;
                break;
            case CubeColor.magenta:
                material.color = Color.magenta;
                break;
            default:
                material.color = Color.white;
                break;
        }

        if (material.color != Color.white)//白以外の時に発光
        {
            emi.material.SetColor("_EmissionColor", material.color);
        }

        //座標
        //x
        if (transform.position.x == 0) mPosX = 0;
        else if (transform.position.x >= -1.05) mPosX = 1;
        else mPosX = 2;
        //y
        if (transform.position.y == 0) mPosY = 0;
        else if (transform.position.y >= -1.05) mPosY = 1;
        else mPosY = 2;

        //正解しているか確認用のGameManagerに情報を送る
        GameManager = GameObject.Find("GameManager");
        gmSc = GameManager.GetComponent<ResponseController>();

        gmSc.mColor[mPosX, mPosY] = (int)cubeColor;
      
    }

    // Update is called once per frame
    void Update()
    {
    }
}
