using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class runPrimaryTrial : MonoBehaviour
{
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

    // Practice Question Text
    static string[] prac_questions = new string[3] {"What is your current fuel efficiency?",
                "What is your current elevation?",
                "Report the sum of the Z coordinates of all active drones."};

    // Practice Question Answers
    static int[] prac_answers = new int[3] { 36, 59, 60 };

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

    // Declare ACtivation Variable
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
        AudioSource[] questionAudioArray = new AudioSource[3] { question1.GetComponent<AudioSource>(), question2.GetComponent<AudioSource>(), question3.GetComponent<AudioSource>() };

        // Trial Information
        Debug.Log("Trial #: " + current_q);
        Debug.Log("Total Q: " + total_questions);
        while (current_q < total_questions)
        {
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
                yield return null;
            }
            
            // Next Question
            current_q++;
        }

        // Return to Menu
        SceneManager.LoadScene(0);
    }

    void checkAnswer()
    {
        // Initialize Audio
        AudioSource correctClip = correctAudio.GetComponent<AudioSource>();
        AudioSource incorrectClip = incorrectAudio.GetComponent<AudioSource>();

        cSymbol.enabled = false;
        iSymbol.enabled = false;
        Debug.Log("In Checked: " + RESPONSE);
        if (RESPONSE == prac_answers[current_q].ToString())
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