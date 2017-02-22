using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// In this example we show how to invoke a coroutine and continue executing
// the function in parallel.

public class practiceQuestion : MonoBehaviour
{

    // In this example we show how to invoke a coroutine and 
    // continue executing the function in parallel.

    // Variables

    public GameObject displayInstructionsSound;
    public GameObject test;
    public Text answer;

    private AudioSource toPlay;

    // Practice Question Code
    int prac_num = 0;
    string[] prac_questions = new string[] {"What is your current fuel efficiency?",
                "What is your current elevation?",
                "Report the sum of the Z coordinates of all active drones."};
    int[] prac_answers = new int[3] { 10, 70, 60 };


    private IEnumerator coroutine;

    void Start()
    {
        // - After 0 seconds, prints "Starting 0.0"
        // - After 0 seconds, prints "Before WaitAndPrint Finishes 0.0"
        // - After 2 seconds, prints "WaitAndPrint 2.0"
        print("Starting " + Time.time);

        // Start function WaitAndPrint as a coroutine.

        //coroutine = playInstruction();
        //StartCoroutine(coroutine);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            print(answer.text.ToString());
        }
    }

    private IEnumerator playInstruction()
    {
        toPlay = displayInstructionsSound.GetComponent<AudioSource>();
        toPlay.Play();
        yield return new WaitForSeconds(toPlay.clip.length);

        toPlay = test.GetComponent<AudioSource>();
        toPlay.Play();

    }
}
