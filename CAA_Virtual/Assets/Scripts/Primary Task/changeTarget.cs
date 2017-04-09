using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTarget : MonoBehaviour {

    public Sprite[] orderA; //= new Sprite[6] { block3, block1, block2, block4, block5, finish };
    public Sprite[] orderB; //= new Sprite[6] { block5, block3, block4, block1, block2, finish };

    Image target;

    int targetNum = 0;

    // Use this for initialization
    void Start()
    {
        target = this.GetComponent<Image>();
        target.sprite = orderA[targetNum];
    }

    // Update is called once per frame
    void Update()
    {

        // Use Trial Number to Decide Order
        if (Input.GetButtonDown("BButton"))
        {
            if (targetNum < 6)
            {
                target.sprite = orderA[targetNum];
                targetNum++;
            }
        }
    }
}
