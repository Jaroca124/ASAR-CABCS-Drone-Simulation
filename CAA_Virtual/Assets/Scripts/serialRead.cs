using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public class serialRead : MonoBehaviour {

    // Access Arduino COM Port
    SerialPort stream = new SerialPort("COM4", 9600); //Set the port (com4) and the baud rate (9600, is standard on most devices);

    // Use this for Initialization
    void Start () {
        stream.Open(); //Open the Serial Stream.
        stream.ReadTimeout = 1;
        //print("started");
    }
	
	// Update is called once per frame
	void Update () {
        if (stream.IsOpen)
        {
            try
            {
                SetAutonomyMode(stream.ReadByte());
            }
            catch(System.Exception)
            {

            }
        }
        else
        {
            //print("Serial Port Not Open");
        }
    }

    void SetAutonomyMode(int input)
    {
        if (input == 100) // Focused
        {
            GameObject.Find("drone").GetComponent<droneMovement>().distracted = false;
            //1:13 PM - 30 minutes (2/6)
        }
        else if (input == 115) // Distracted
        {
            GameObject.Find("drone").GetComponent<droneMovement>().distracted = true;
        }
    }
}
