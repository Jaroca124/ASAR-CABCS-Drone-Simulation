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

    // Declare Coroutine
    private IEnumerator coroutine;

    // Declare Response Variables
    string RESPONSE;
    public Image cSymbol;
    public Image iSymbol;

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
            cSymbol.enabled = true;
            Debug.Log("Checking Answer");
            RESPONSE = GameObject.Find("InputField").GetComponent<userInput>().UserResponse.ToString(); //Figure out why the response is empty
            checkAnswer();
        }
    }

    public IEnumerator trialFunction() {

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
                Debug.Log("Waiting");
                //checkAnswer();
                yield return null;
            }
            
            // Next Question
            current_q++;
        }
        Debug.Log("Done");
    }

    void checkAnswer()
    {
        cSymbol.enabled = false;
        iSymbol.enabled = false;
        Debug.Log("In Checked: " + RESPONSE);
        if (RESPONSE == prac_answers[current_q].ToString())
        {
            CORRECT = true;
            iSymbol.enabled = false;
            cSymbol.enabled = true;
            Debug.Log("Success MOFO");
        }
        else
        {
            Debug.Log("Incorrect");
            cSymbol.enabled = false;
            iSymbol.enabled = true;
        }
    }
}