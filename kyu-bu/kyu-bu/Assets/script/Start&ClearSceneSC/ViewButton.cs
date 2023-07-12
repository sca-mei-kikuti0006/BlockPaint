using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewButton : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnButton()//ƒ{ƒ^ƒ“‚ð‰Ÿ‚µ‚½‚ç•\Ž¦‚·‚é
    {
        canvas.SetActive(true);
    }
    
}
