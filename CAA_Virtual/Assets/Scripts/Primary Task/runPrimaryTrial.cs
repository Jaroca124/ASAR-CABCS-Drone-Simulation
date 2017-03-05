﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class runPrimaryTrial : MonoBehaviour
{
    // Trial Information
    string[] q_text_array = new string[6] {"What is your current fuel efficiency?",
                "What is your current elevation?","What is your current elevation minus 17?",
                "What is your current fuel efficiency plus 56?",
                "Report the sum of the X coordinates of all active drones.",
                "Report the sum of the Y coordinates of all active drones."};

    string[] instr1 = new string[4] {"Pilot, your mission is to conduct surveillance on five different locations.",
           "You will also have to update your dispatch with flight diagnostics.",
           "Mission success is based on your time of completion of both the surveillance and your updates.",
           "Good luck."};

    string[] instr2 = new string[3] {"Pilot, you will conduct another surveillance mission.",
           "Execute with the same instructions as your previous mission.",
           "Good luck."};

    string[] launch_text = new string[2] {"Preparing Launch... Running Final Scans...",
               "Liftoff in..."};

    //Participant Data
    static int SUBID = 0;

    //Answers
    int[] q_answer_array = new int[6] { 36, 59, 42, 92, 165, 131 };

    // Counterbalanced Question Orders
    static int[][] counterbalance_qarray = new int[][] {
        new int[] { 1, 3, 5, 2, 4, 6 },
        new int[] { 1, 3, 6, 2, 4, 5 },
        new int[] { 1, 4, 5, 2, 3, 6 },
        new int[] { 1, 4, 6, 2, 3, 5 },
        new int[] { 2, 3, 5, 1, 4, 6 },
        new int[] { 2, 3, 6, 1, 4, 5 },
        new int[] { 2, 4, 5, 1, 3, 6 },
        new int[] { 2, 4, 6, 1, 3, 5 },
    };

    // Assign Trial Question Order
    int counterb_index = (SUBID % 8) + 1;
    int[] question_array = new int[6] { counterbalance_qarray[SUBID][0], counterbalance_qarray[SUBID][1], counterbalance_qarray[SUBID][2], counterbalance_qarray[SUBID][3], counterbalance_qarray[SUBID][4], counterbalance_qarray[SUBID][5] };

    // Create Variable for Keeping Track of Distraction Index Across Trials
    int question_index = 1;

    // Create Current Trial Number Variable
    int trial_number = PlayerPrefs.GetInt("trial_number");

    static int total_questions = 3;
    int current_q = 0;
    int index;
    bool CORRECT;

    // Create Timing Variables;
    float trialOneTime = 0;
    float trialTwoTime = 0;
    float[] question_time = new float[6];

    ///////////////////////////////////////////////////

    // Audio - Dispatch Response
    public GameObject alertAudio;
    public GameObject correctAudio;
    public GameObject incorrectAudio;
    public GameObject displayInstructionsSound;

    // Audio - Questions
    public GameObject question1;
    public GameObject question2;
    public GameObject question3;

    // Declare Play Variable
    private AudioSource toPlay;

    // Declare Coroutine
    private IEnumerator coroutine;

    // Declare Response Variables
    string RESPONSE;
    public Image cSymbol;
    public Image iSymbol;

    // Declare Activation Variable
    bool TRIGGER = false;

    void Start()
    {
        cSymbol.enabled = false;
        iSymbol.enabled = false;
        StartCoroutine("trialFunction");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RESPONSE = GameObject.Find("GameController").GetComponent<userInput>().UserResponse.ToString();
            Debug.Log("Checking Answer: " + RESPONSE);
            checkAnswer();
        }
    }

    public IEnumerator trialFunction() {

        // Initialize Audio
        //AudioSource[] questionAudioArray = new AudioSource[3] { question1.GetComponent<AudioSource>(), question2.GetComponent<AudioSource>(), question3.GetComponent<AudioSource>() };

        // Trial Information
        Debug.Log("Trial #: " + current_q);
        Debug.Log("Total Q: " + total_questions);
        while (current_q < total_questions)
        {
            if (trial_number == 2)
            {
                index = current_q + 3;
            }
            else
            {
                index = current_q;
            }
            // Reset Variables
            float startTime = Time.time;
            CORRECT = false;
            GameObject.Find("instructionText").GetComponent<Text>().text = "";

            // Wait for Timer
            while (!TRIGGER)
            {
                Debug.Log("Waiting for Trigger");
                yield return null;
                TRIGGER = false;
            }

            //Play Alert Noise
            alertAudio.GetComponent<AudioSource>().Play();

            Debug.Log("Starting Trial");
            // Grab Trial Variables
            Debug.Log("Trial Answer: " + q_answer_array[index]);

            // Display Question
            GameObject.Find("instructionText").GetComponent<Text>().text = q_text_array[index];

            // Play Question
            //questionAudioArray[current_q].Play();

            //Initialize Response Start
            float start_time = Time.time;

            // Check Participant's Answer
            while (!CORRECT)
            {
                Debug.Log("Waiting");
                yield return null;
            }
            
            // Next Question
            current_q++;
        }

        // Transition: Second Trial or End
        if (trial_number == 1)
        {
            int temp_trial = PlayerPrefs.GetInt("trial_number");
            PlayerPrefs.SetInt("temp_trial", temp_trial + 1); //Increment Trial Number
            // Load Break Scene
        }
        else if (trial_number == 2)
        {
            // Log Data?
            int temp_subid = PlayerPrefs.GetInt("subid");
            PlayerPrefs.SetInt("subid", temp_subid + 1); //Increment Subid
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Error");
        }
    }

    void checkAnswer()
    {
        // Initialize Audio
        AudioSource correctClip = correctAudio.GetComponent<AudioSource>();
        AudioSource incorrectClip = incorrectAudio.GetComponent<AudioSource>();

        cSymbol.enabled = false;
        iSymbol.enabled = false;
        Debug.Log("In Checked: " + RESPONSE);
        if (RESPONSE == q_answer_array[index].ToString())
        {
            CORRECT = true;
            correctClip.Play();
            iSymbol.enabled = false;
            cSymbol.enabled = true;
            StartCoroutine("FadeCorrect");
        }
        else
        {
            incorrectClip.Play();
            cSymbol.enabled = false;
            iSymbol.enabled = true;
            StartCoroutine("FadeIncorrect");
        }
    }

    IEnumerator FadeCorrect()
    {
        float startTime = Time.time;
        while (Time.time < startTime + 1.0f)
        {
            yield return null;
        }
        cSymbol.enabled = false;
    }

    IEnumerator FadeIncorrect()
    {
        float startTime = Time.time;
        yield return new WaitForSeconds(1);
        iSymbol.enabled = false;
    }

}