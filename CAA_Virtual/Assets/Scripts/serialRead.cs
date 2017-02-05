using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public class serialRead : MonoBehaviour {

    // Access Arduino COM Port
    SerialPort stream = new SerialPort("COM3", 9600); //Set the port (com4) and the baud rate (9600, is standard on most devices)

    // Use this for initialization
    void Start () {
        stream.Open(); //Open the Serial Stream.
        stream.ReadTimeout = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (stream.IsOpen)
        {
            try
            {
                SetAutonomyMode(stream.ReadByte());
                print(stream.ReadByte());
            }
            catch
            {

            }
        }
    }

    void SetAutonomyMode(int input)
    {
        print("Success");
    }
}
