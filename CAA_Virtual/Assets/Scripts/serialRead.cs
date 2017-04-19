using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System;

public class serialRead : MonoBehaviour {

    public static SerialPort serialPort = new SerialPort("COM3", 38400, Parity.None, 8, StopBits.One);
    public static string strIn;

    void Start()
    {
        OpenConnection();
    }

    void FixedUpdate()
    {
        Debug.Log(serialPort.ReadLine());
    }

    public void OpenConnection()
    {
        if (serialPort != null)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                Debug.Log("Closing port, because it was already open!");
            }
            else
            {
                serialPort.Open();
                serialPort.ReadTimeout = 5000;
                Debug.Log("Port Opened!");
            }
        }
        else
        {
            if (serialPort.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }

    void OnApplicationQuit()
    {
        serialPort.Close();
        Debug.Log("Port closed!");
    }
}
