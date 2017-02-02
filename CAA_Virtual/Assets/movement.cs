using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    //float speed = 10.0f;
    //public float thrust;
    //public Rigidbody drone;

    public float speed = 90f;
    public float rollFactor = 5f;
    private float powerInput;
    private Rigidbody drone;

    void Awake()
    {
        drone = GetComponent<Rigidbody>();
    }
     
    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        drone.AddRelativeForce(powerInput * speed, 0f, 0f);
        //float z = powerInput * 15.0f; // might be negative, just test it
        //Vector3 euler = transform.localEulerAngles;
        //euler.z = Mathf.Lerp(euler.z, z, 2.0f * Time.deltaTime);
        //transform.localEulerAngles = euler;
    }
}