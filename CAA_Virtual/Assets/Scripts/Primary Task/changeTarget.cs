using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTarget : MonoBehaviour {

    public Sprite[] orderA;
    public Sprite[] orderB;

    public Text condition;

    Image target;
    public int targetNum = 0;
    int order;
    int trial;
    public char targetORDER = 'a';

    runPrimaryTrial runPrimaryTrial;

    // Use this for initialization
    void Start()
    {
        target = this.GetComponent<Image>();
        order = PlayerPrefs.GetInt("Order");
        trial = PlayerPrefs.GetInt("Trial");
        Debug.Log("Order: " + order);
        Debug.Log("Trial: " + trial);

        // Set Starting Target
        if (trial == 1)
        {
            if (order % 2 == 0)
            {
                target.sprite = orderA[0];
                targetORDER = 'a';
            }
            else
            {
                target.sprite = orderB[0];
                targetORDER = 'b';
            }
        }
        if (trial == 2)
        {
            if (order % 2 == 0)
            {
                target.sprite = orderB[0];
                targetORDER = 'b';
            }
            else
            {
                target.sprite = orderA[0];
                targetORDER = 'a';
            }
        }

        GameObject GameController = GameObject.Find("Drone_red");
        DroneMovementScript primaryScript = GameController.GetComponent<DroneMovementScript>();

        GameObject starting = GameObject.Find("GameController");
        runPrimaryTrial = starting.GetComponent<runPrimaryTrial>();

        if (primaryScript.continuous)
        {
            condition.text = "Continuous";
        }
        else
        {
            condition.text = "Discrete";
        }
        targetNum++;

    }

    // Update is called once per frame
    void Update()
    {
        // Use Trial Number to Decide Order
        if (runPrimaryTrial.START && Input.GetButtonDown("BButton"))
        {
            if (targetNum < 6)
            {
                if (trial == 1) {
                    if (order % 2 == 0)
                        target.sprite = orderA[targetNum];
                    else
                        target.sprite = orderB[targetNum];
                }
                if (trial == 2) {
                    if (order % 2 == 0)
                        target.sprite = orderB[targetNum];
                    else
                        target.sprite = orderA[targetNum];
                }
                targetNum++;
            }
        }
    }
}
