using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)) {

            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * 5, Input.GetAxis("Mouse X") * -5, 0));
        }
    }
}
