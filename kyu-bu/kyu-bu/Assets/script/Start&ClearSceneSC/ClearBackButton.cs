using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearBackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButton()//�{�^������������X�^�[�g�V�[���Ɉړ�����
    {
        SceneManager.LoadScene("StartScene");
    }

}
