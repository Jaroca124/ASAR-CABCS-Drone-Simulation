using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {


    public string experimentTitle;
    public int participantNumber;
    public int particpantAge;
    public string participantGender;

	public void LoadByIndex(int sceneIndex)
    {
        experimentTitle = GameObject.Find("ExperimentName").GetComponentInChildren<InputField>().text.ToString();
        participantNumber = int.Parse(GameObject.Find("ParticipantNumber").GetComponentInChildren<InputField>().text);
        particpantAge = int.Parse(GameObject.Find("ParticipantAge").GetComponentInChildren<InputField>().text);
        participantGender = GameObject.Find("ParticipantGender").GetComponentInChildren<InputField>().text;
        SceneManager.LoadScene(sceneIndex);
    }
}
