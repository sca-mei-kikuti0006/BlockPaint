using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
   enum CubeColor { 
        red = 1,
        blue,
        green,
        yellow,
        magenta,
        cyan,
        white
        };
    // Start is called before the first frame update
    void Start()
    {

        Material material = this.GetComponent<Renderer>().material;

        int random = Random.Range(1,6);
        CubeColor cubeColor = (CubeColor)random;
        switch (random) { 
            case 1:
                material.color = Color.red;
                break;
            case 2:
                material.color = Color.blue;
                break;
            case 3:
                material.color = Color.green;
                break;
            case 4:
                material.color = Color.yellow;
                break;
            case 5:
                material.color = Color.magenta;
                break;
            case 6:
                material.color = Color.cyan;
                break;
            default:
                material.color = Color.white;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
