using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Управление : MonoBehaviour
{
    public float Speed = 15;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 70;
        }
        else
        {
            Speed = 15;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.left * Speed * Time.deltaTime);
        }


    }
}
