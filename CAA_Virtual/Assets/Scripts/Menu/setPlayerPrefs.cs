using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("subid") == 0) {
            PlayerPrefs.SetInt("subid", 1);
        }
        int subid = PlayerPrefs.GetInt("subid");
        Debug.Log("Subid: " + subid);
        PlayerPrefs.SetInt("trial_number", 1);
        Debug.Log("Trial Number: + " + PlayerPrefs.GetInt("trial_number"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
