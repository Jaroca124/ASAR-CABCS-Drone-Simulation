using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondaryTaskScript : MonoBehaviour {

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

    // Total Distractions per Trial
    int max_trial_disctractions = 3;

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
    int[] question_array = new int[6] { counterbalance_qarray[SUBID][0], counterbalance_qarray[SUBID][1], counterbalance_qarray[SUBID][2] , counterbalance_qarray[SUBID][3] , counterbalance_qarray[SUBID][4], counterbalance_qarray[SUBID][5]};

    // Create Variable for Keeping Track of Distraction Index Across Trials
    int question_index = 1;

    // Create Current Trial Number Variable
    int current_trial = 1;

    // Create Timing Variables;
    float trialOneTime = 0;
    float trialTwoTime = 0;
    float[] question_time = new float[6];

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
