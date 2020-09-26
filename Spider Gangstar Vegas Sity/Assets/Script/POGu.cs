using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class POGu : MonoBehaviour
{
     public int myInt = 5;
    public float MoveSpeed = 4;
    public float Jump = 7;
    private Rigidbody rb;
    public GameObject obj;
      void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(transform.position.x);
        }
        float Hm = Input.GetAxis("Horizontal");
        float Vm = Input.GetAxis("Vertical");
        Vector3 V3M = new Vector3(Hm, 0, Vm);
        rb.AddForce(V3M * -MoveSpeed);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Jump);
            obj.SetActive(true);
        }       
        else
        {
            obj.SetActive(false);
        }
    }
}
