using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyButton : MonoBehaviour
{
    [SerializeField] private Text easyText;

    private static bool _easy = true;

    // Start is called before the first frame update
    void Start()
    {
        easyText.text = "EASY";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButton()//ƒ{ƒ^ƒ“‚Å“ïˆÕ“x‚ğØ‚è‘Ö‚¦‚é
    {
        if (_easy)
        {
            easyText.text = "HARD";
            _easy = false;
        }
        else
        {
            easyText.text = "EASY";
            _easy = true;
        }
        
    }

    //getter
    public static bool easy
    {
        get { return _easy; }
    }
}
