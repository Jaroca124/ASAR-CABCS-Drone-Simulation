using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class runPrimaryTrial : MonoBehaviour
{

    // Declare Subid
    static int SUBID;
    int trial_number;

    // Declare Trigger Times
    // Based on Total Distance Travelled
    float distanceTotal = 0;
    float xPos;

    // Targets
    int identified;
    bool finalReached;

    // Time
    float TOC;
    float time; 

    void Start()
    {
        trial_number = PlayerPrefs.GetInt("trial_number");

        time = Time.time;
        identified = 0;
        finalReached = false;

        SUBID = PlayerPrefs.GetInt("subid");
        Debug.Log("SUBID: " + SUBID);

        xPos = GameObject.Find("Drone_red").transform.position.x;

    }

    void Update()
    {
        xPos = GameObject.Find("Drone_red").transform.position.x;

        if (Time.time > 10.0f && (xPos > -5.0 && xPos < 5.0f))
        {
            finalReached = true;
            Debug.Log("Done");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            identified++;
        }

        if (identified >= 5 && finalReached)
        {
            TOC = Time.time - time;
            Debug.Log("Total Trial Time: " + TOC);
            //int temp_trial = PlayerPrefs.GetInt("trial_number");
            //PlayerPrefs.SetInt("temp_trial", temp_trial + 1); //Increment Trial Number
            //SceneManager.LoadScene(3);
        }
    }
}