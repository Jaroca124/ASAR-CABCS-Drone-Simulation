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
    static int[] prac_answers = new int[3] { 10, 70, 60 };

    // Trial Variables
    static int total_questions = 3;
    int current_q = 0;
    bool CORRECT = false;

    private IEnumerator coroutine;

    // TAKE OUT
    string RESPONSE;

    void Start()
    {
        // Begin Trial
        trialFunction();
    }

    public void trialFunction() {

        print("Starting " + Time.time);

        // Initialize Audio
        //AudioSource correctClip = correctAudio.GetComponent<AudioSource>();
        //AudioSource incorrectClip = incorrectAudio.GetComponent<AudioSource>();
        //AudioSource[] questionAudioArray = new AudioSource[3] { question1.GetComponent<AudioSource>(), question2.GetComponent<AudioSource>(), question3.GetComponent<AudioSource>() };

        Debug.Log("Starting Coroutine");
        Debug.Log("Trial #: " + current_q);
        Debug.Log("Total Q: " + total_questions);
        while (current_q < total_questions)
        {
            Debug.Log("Starting Trial");
            // Grab Trial Variables
            int q_answer = prac_answers[current_q];
            Debug.Log("Trial Answer: " + q_answer);

            // Display Question
            // TODO

            // Play Question
            //questionAudioArray[current_q].Play();
            //float start_time = Time.time;
            //while (start_time + questionAudioArray[current_q].clip.length + Time.time < Time.time)
            //{
            //    Debug.Log("Waiting");
            //}

            // Check Participant's Answer
            while (!CORRECT)
            {
                if (RESPONSE == prac_answers[current_q].ToString())
                {
                    CORRECT = true;
                    Debug.Log("Correct");
                    //correctClip.Play();
                }
                else
                {
                    Debug.Log("INCORRECT");
                    //incorrectClip.Play();
                }
            }

            current_q++;
        }
        Debug.Log("Done");

        //Start Coroutine
        //coroutine = playInstruction();
        //StartCoroutine(coroutine);

    }

    void Update()
    {
        // Can now access the variable, but the program crashes when i run it. I need to figure out how to access the response variable continuously // maybe search (wait until variable is correct unity?
        RESPONSE = GameObject.Find("InputField").GetComponentInChildren<InputField>().text.ToString();
    }

    /*
    private IEnumerator playInstruction()
    {
        // Initialize Audio
        AudioSource correctClip = correctAudio.GetComponent<AudioSource>();
        AudioSource incorrectClip = incorrectAudio.GetComponent<AudioSource>();
        AudioSource[] questionAudioArray = new AudioSource[3] { question1.GetComponent<AudioSource>(), question2.GetComponent<AudioSource>(), question3.GetComponent<AudioSource>() };

        Debug.Log("Starting Coroutine");
        Debug.Log("Trial #: " + current_q);
        Debug.Log("Total Q: " + total_questions);
        while (current_q < total_questions)
        {
            Debug.Log("Starting Trial");
            // Grab Trial Variables
            int q_answer = prac_answers[current_q];
            Debug.Log("Trial Answer: " + q_answer);

            // Display Question
            // TODO

            // Play Question
            questionAudioArray[current_q].Play();
            yield return new WaitForSeconds(questionAudioArray[current_q].clip.length);

            // Check Participant's Answer
            while (!CORRECT)
            {
                
                Debug.Log(RESPONSE);
                if (RESPONSE == prac_answers[current_q].ToString())
                {
                    CORRECT = true;
                    correctClip.Play();
                }
                else
                {
                    incorrectClip.Play();
                }
            }

            current_q++;
        }
        Debug.Log("Done");
    }*/
}