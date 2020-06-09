using UnityEngine;
using System;


public class Yuliy : MonoBehaviour
{
    public Transform PosTarget;
    public float TurnSpeed = 5;


    // Update is called once per frame
    void Update()
    {
        Vector3 dir = PosTarget.position - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (dir), TurnSpeed * Time.deltaTime);
        Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
        PosTarget.position = ray.GetPoint(60);
    }
}
