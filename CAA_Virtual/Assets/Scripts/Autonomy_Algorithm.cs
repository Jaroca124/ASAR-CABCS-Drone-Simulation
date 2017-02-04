using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autonomy_Algorithm : MonoBehaviour {

    public bool distracted;
    public bool continuous;
    public Vector3 velocity;
    public Rigidbody drone;

	// Use this for initialization
	void Start () {
        drone = GetComponent<Rigidbody>();
    }
	
    //15 m/s -> 31.26 Speed
	// Update is called once per frame
	void Update () {
        velocity = drone.velocity;
        print(velocity);
        if (distracted && continuous)
        {
            
        }
	}
}
