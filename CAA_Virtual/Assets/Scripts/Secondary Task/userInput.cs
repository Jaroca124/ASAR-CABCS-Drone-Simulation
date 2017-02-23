using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userInput : MonoBehaviour {

    private InputField input;
    public string UserResponse;

    void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    public void GetInput(string user_input)
    {
        UserResponse = user_input;
        Debug.Log(UserResponse);
        input.text = "";
    }
	
}
