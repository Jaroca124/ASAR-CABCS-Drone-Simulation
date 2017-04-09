using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class setGame : MonoBehaviour {

    public InputField expName;
    public InputField partNumber;
    public InputField partAge;
    public InputField partGender;

    // Use this for initialization
    void Start () {
		
	}

    public void GameSetup() {
        string Name = expName.text;
        string Number = partNumber.text;
        string Age = partAge.text;
        string Gender = partGender.text;

        // Calculate & Player Prefs
        int Num = Int32.Parse(Number);
        PlayerPrefs.SetInt("SUBID", Num);
        PlayerPrefs.SetString("Gender", Gender);
        PlayerPrefs.SetString("Age", Age);
        PlayerPrefs.SetString("ExpName", Name);
        PlayerPrefs.SetInt("Autonomy", Num % 2);
        int Order;
        if ((Num + (Num % 2)) % 4 == 0)
        {
            Order = 0;
        }
        else
        {
            Order = 1;
        }
        PlayerPrefs.SetInt("Order", Order);
        PlayerPrefs.SetInt("Trial", 1);
    }
}
