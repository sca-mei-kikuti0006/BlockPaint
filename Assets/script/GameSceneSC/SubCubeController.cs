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

    //�}�E�X�N���b�N������
    private bool inputR = false;
    private bool inputB = false;
    private bool inputW = false;

    [SerializeField]private Material redMate;
    [SerializeField] private Material blueMate;
    [SerializeField] private Material magentaMate;

    private bool easyOr = EasyButton.easy;//��Փx

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

        //���W
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
        if (Input.GetKey(KeyCode.Mouse0))     //���N���b�N�͐�
        {
            inputR  = true;
        }
        else if (Input.GetKey(KeyCode.Mouse1))//�E�N���b�N�͐�
        {
            inputB = true;
        }
        else if (Input.GetKey(KeyCode.Mouse2))//�}�E�X�z�C�[���͔�
        {
            inputW = true;
        }
        else {
            inputR = false;
            inputB = false;
            inputW = false;
        }


        //cube�̐F
        if(material.color == Color.red) color = CubeColor.red;
        else if (material.color == Color.blue) color = CubeColor.blue;
        else if (material.color == Color.magenta) color = CubeColor.magenta;
        else  color = CubeColor.white;


        //�������Ă��邩�m�F�p��GameManager�ɏ��𑗂�
        gmSc.sColor[sPosX, sPosY] = (int)color;

        luminescence();//�������Ă����甭������
    }

    //�F��ς���֐�
    public void OnClickObject() {
        if(inputR  == true) {                     //���N���b�N�����Ƃ�
            if(material.color == Color.blue)      //cube���������Ƃ��͎��ɂ���
            {
                material.color = Color.magenta;
            }
            else if(material.color == Color.white)//cube�����������Ƃ��͐Ԃɂ���
            {
                material.color = Color.red;
            }
        }
        else if (inputB == true){                 //�E�N���b�N�����Ƃ�
            if (material.color == Color.red)      //cube���Ԃ������Ƃ��͎��ɂ���
            {
                material.color = Color.magenta;
            }
            else if(material.color == Color.white)//cube�����������Ƃ��͐ɂ���
            {
                material.color = Color.blue;
            }
        }
        else if (inputW == true)                  //�}�E�X�z�C�[�����N���b�N�����Ƃ����ɂ���
        {
            material.color = Color.white;
            emi.material.SetColor("_EmissionColor", new Color(0.0f,0.0f,0.0f,0.0f));
        }
        
    }

    void luminescence(){//�������Ă����甭������
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
