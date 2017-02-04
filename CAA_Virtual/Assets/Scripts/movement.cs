using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    //float speed = 10.0f;
    //public float thrust;
    //public Rigidbody drone;

    // Drone Properties
    public float SPEED;
    public float ROLLFACTOR;
    private float powerInput;
    public Vector3 velocity;
    private Rigidbody drone;

    //
    public bool distracted;
    public bool continuous;

    void Awake()
    {
        drone = GetComponent<Rigidbody>();
        SPEED = 30.26f;
        ROLLFACTOR = 5f;
}
     
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        velocity = drone.velocity;
        powerInput = Input.GetAxis("Vertical");
        if (distracted == false) // Normal Movement
        {
            drone.AddRelativeForce(powerInput * SPEED, 0f, 0f);
        }
        else if (distracted && continuous == false) // Discrete Condition
        {
            drone.velocity = new Vector3(0, 0, 0);
        }
    }
}