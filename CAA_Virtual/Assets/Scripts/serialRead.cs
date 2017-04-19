using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System;
using System.Linq;

public class serialRead : MonoBehaviour {

 public static SerialPort sp;
 public static string x;


 // Use this for initialization
 void Start () 
 {
    
        //Debug.Log ("Code started");
        OpenConnection();
     //Debug.Log ("initialzed properly");
 }
 
 void Update() 
     {
        x = sp.ReadLine();
        readData(Int32.Parse(x));
        sp.ReadTimeout = 25;
     }
 
     
 public void OpenConnection() 
 {
     sp = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
     sp.DtrEnable = true;
     Debug.Log ("OpenConnection started");
     if (sp != null)
     {
        if (sp.IsOpen) 
        {
          sp.Close();
          Debug.Log ("Closing port, because it was already open!");
        }
        else 
        {
          sp.Open();  // opens the connection
          // sets the timeout value before reporting error
         Debug.Log("Port Opened!");
        }
     }
     else 
     {
        if (sp.IsOpen)
        {
          print("Port is already open");
        }
        else 
        {
          print("Port == null");
        }
     }
         Debug.Log ("Open Connection finished running");
     }
     
void readData(int data)
{
    GameObject GameController = GameObject.Find("Drone_red");
    DroneMovementScript script = GameController.GetComponent<DroneMovementScript>();
    if (data == 1) {
        script.distracted = false;
    }
    else if (data == 2) {
        script.distracted = true;
    }
    else {
        Debug.Log("Error");
    }
}

 void OnApplicationQuit()
     {
         if (sp != null)
             sp.Close();
     }
 }
