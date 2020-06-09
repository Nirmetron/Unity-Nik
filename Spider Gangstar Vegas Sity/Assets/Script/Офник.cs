using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Офник : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && GetComponent<Yuliy>().enabled == true)
        {
            GetComponent<Yuliy>().enabled = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.L) && GetComponent<Yuliy>().enabled == false)
            {
                GetComponent<Yuliy>().enabled = true;
            }
        }
    }
}
