using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDsController : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * 5, Input.GetAxis("Mouse X") * -5, 0));
        }
    }

    public void RotateRest(){
        transform.rotation = Quaternion.identity;
    }
}
