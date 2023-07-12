using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButton()//ƒ{ƒ^ƒ“‚ð‰Ÿ‚µ‚½‚ç”ñ•\Ž¦‚É‚·‚é
    {
        canvas.SetActive(false);
    }
}
