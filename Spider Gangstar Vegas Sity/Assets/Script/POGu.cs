using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class POGu : MonoBehaviour
{
     public int myInt = 5;
    public float MoveSpeed = 3;
    public float Jump = 5;
    private Rigidbody rb;
    public GameObject obj;
      void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
       
        float Hr = Input.GetAxis("Horizontal");
        float Vr = Input.GetAxis("Vertical");
        rb.AddForce(((transform.right * Hr) + (transform.forward * Vr)) * MoveSpeed / Time.deltaTime);
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
