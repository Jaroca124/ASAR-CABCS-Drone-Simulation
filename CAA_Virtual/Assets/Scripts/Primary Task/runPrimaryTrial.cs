using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

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

    // Time
    float TOC;
    float time;
    bool logged = false;

    // Autonomy
    public bool distracted;
    // Discrete: Autonomy == 0  Continuous: Autonomy == 1
    public bool continuous;

    void Start()
    {
        // Grab SUBID and Trial Number
        SUBID = PlayerPrefs.GetInt("SUBID");
        Debug.Log("SUBID: " + SUBID);
        trial_number = PlayerPrefs.GetInt("Trial");
        Debug.Log("Starting Trial " + trial_number);

        time = Time.time;
        identified = 0;

        xPos = GameObject.Find("Drone_red").transform.position.x;

        // Get Autonomy Condition
        int condition = PlayerPrefs.GetInt("Autonomy");
        if (trial_number == 1)
        {
            if (condition % 2 == 0)
                continuous = false;
            else
                continuous = true;
        }
        if (trial_number == 2)
        {
            if (condition % 2 == 0)
                continuous = true;
            else
                continuous = false;
        }

    }

    void Update()
    {
        xPos = GameObject.Find("Drone_red").transform.position.x;

        if (Input.GetButtonDown("BButton"))
        {
            identified++;
        }

        if (Time.time > 10.0f && (xPos > -5.0 && xPos < 5.0f) && identified > 5)
        {
            if (!logged)
            {
                log_data();
                logged = true;
            }
        }
    }

    void log_data()
    {
        TOC = Time.time - time;
        Debug.Log("Trial " + trial_number + " Time: " + TOC);
        if (trial_number == 1) {
            PlayerPrefs.SetFloat("Trial1Time", TOC);
            int temp_trial = PlayerPrefs.GetInt("Trial");
            PlayerPrefs.SetInt("Trial", temp_trial + 1); //Increment Trial Number
            SceneManager.LoadScene(2);
        }
        else
        {
            PlayerPrefs.SetFloat("Trial2Time", TOC);
            Savecsv();
            SceneManager.LoadScene(0);
        }
    }

    public void Savecsv()
    {

        string filePath = "C:/Users/Jake/Documents/GitHub/CAA_Virtual/CAA_Virtual/Assets/Data/data.csv";
        string delimiter = ",";

        // Calculate & Player Prefs
        int Num = PlayerPrefs.GetInt("SUBID");
        string Gender = PlayerPrefs.GetString("Gender");
        string Age = PlayerPrefs.GetString("Age");
        string ExpName = PlayerPrefs.GetString("ExpName");
        int autonomy = PlayerPrefs.GetInt("Autonomy");
        int order = PlayerPrefs.GetInt("Order");
        float t1 = PlayerPrefs.GetFloat("Trial1Time");
        float t2 = PlayerPrefs.GetFloat("Trial2Time");

        // String Together Data
        string[] output = new string[] { ExpName, Num.ToString(), Age, Gender, autonomy.ToString(), order.ToString(), t1.ToString(), t2.ToString() };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(string.Join(delimiter, output));

        File.AppendAllText(filePath, sb.ToString(), Encoding.UTF8);
    }
}