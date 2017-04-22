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
    public Sprite[] targets;

    // Time
    float TOC;
    float time;
    bool logged = false;

    void Start()
    {
        load_targets();
        // Grab SUBID and Trial Number
        SUBID = PlayerPrefs.GetInt("SUBID");
        Debug.Log("SUBID: " + SUBID);
        trial_number = PlayerPrefs.GetInt("Trial");
        Debug.Log("Starting Trial " + trial_number);

        time = Time.time;
        identified = 0;

        xPos = GameObject.Find("Drone_red").transform.position.x;

    }

    void Update()
    {
        xPos = GameObject.Find("Drone_red").transform.position.x;

        if (Input.GetButtonDown("BButton"))
        {
            identified++;
        }

        if (Time.time > 10.0f && (xPos > -5.0 && xPos < 5.0f) && identified > 4)
        {
            if (!logged)
            {
                log_data();
                logged = true;
            }
        }
    }

    void load_targets()
    {
        GameObject.Find("target_1").GetComponent<SpriteRenderer>().sprite = targets[Random.Range(0, 5)];
        GameObject.Find("target_2").GetComponent<SpriteRenderer>().sprite = targets[Random.Range(0, 5)];
        GameObject.Find("target_3").GetComponent<SpriteRenderer>().sprite = targets[Random.Range(0, 5)];
        GameObject.Find("target_4").GetComponent<SpriteRenderer>().sprite = targets[Random.Range(0, 5)];
        GameObject.Find("target_5").GetComponent<SpriteRenderer>().sprite = targets[Random.Range(0, 5)];
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