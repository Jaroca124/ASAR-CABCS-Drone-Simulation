using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practiceQuestion : MonoBehaviour {

    public GameObject sound;
    private AudioSource toPlay;

    // Practice Question Code
    int prac_num = 0;
    string[] prac_questions = new string[] {"What is your current fuel efficiency?",
                "What is your current elevation?",
                "Report the sum of the Z coordinates of all active drones."};
    int[] prac_answers = new int[3] { 10, 70, 60 };

    // Use this for initialization
    void Start () {
        print("start");
        runPractice();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator runPractice() {

        print("HelloWorld");
        toPlay = sound.GetComponent<AudioSource>();

        while (prac_num < 3)
        {
            toPlay.Play();
            yield return new WaitForSeconds(37);
            print("Test");

            prac_num++;
        }
    }
}
