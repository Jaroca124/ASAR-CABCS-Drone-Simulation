using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class runTrial : MonoBehaviour
{

    // In this example we show how to invoke a coroutine and 
    // continue executing the function in parallel.

    // Variables

    public GameObject displayInstructionsSound;

    // Audio - Dispatch Response
    public GameObject correctAudio;
    public GameObject incorrectAudio;

    // Audio - Questions
    public GameObject question1;
    public GameObject question2;
    public GameObject question3;

    // Declare Play Variable
    private AudioSource toPlay;

    // Practice Question Text
    static string[] prac_questions = new string[3] {"What is your current fuel efficiency?",
                "What is your current elevation?",
                "Report the sum of the Z coordinates of all active drones."};

    // Practice Question Answers
    static int[] prac_answers = new int[3] { 36, 70, 60 };

    // Trial Variables
    static int total_questions = 3;
    int current_q = 0;
    bool CORRECT;

    private IEnumerator coroutine;

    // TAKE OUT
    string RESPONSE;

    void Start()
    {
    }

    public IEnumerator trialFunction() {

        //print("Starting " + Time.time);

        // Initialize Audio
        AudioSource correctClip = correctAudio.GetComponent<AudioSource>();
        AudioSource incorrectClip = incorrectAudio.GetComponent<AudioSource>();
        AudioSource[] questionAudioArray = new AudioSource[3] { question1.GetComponent<AudioSource>(), question2.GetComponent<AudioSource>(), question3.GetComponent<AudioSource>() };

        Debug.Log("Trial #: " + current_q);
        Debug.Log("Total Q: " + total_questions);
        while (current_q < total_questions)
        {
            CORRECT = false;
            Debug.Log("Starting Trial");
            // Grab Trial Variables
            Debug.Log("Trial Answer: " + prac_answers[current_q]);

            // Display Question
            GameObject.Find("instructionText").GetComponent<Text>().text = prac_questions[current_q];

            // Play Question
            //questionAudioArray[current_q].Play();

            //Initialize Response Start
            float start_time = Time.time;

            // Check Participant's Answer
            while (!CORRECT)
            {
                RESPONSE = GameObject.Find("InputField").GetComponentInChildren<InputField>().text.ToString();
                if (RESPONSE == prac_answers[current_q].ToString())
                {
                    CORRECT = true;
                    correctClip.Play();
                    Debug.Log("Success MOFO");
                }
                else
                {
                    incorrectClip.Play();
                }
                yield return null;
            }
            current_q++;
        }
        Debug.Log("Done");
    }

    void Update()
    {
        StartCoroutine("trialFunction");
    }
}