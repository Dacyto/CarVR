using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLight : MonoBehaviour
{
    public Material carBodyColor;
    public Material lightButton;
    public GameObject light1; // передние фары
    public GameObject light2; // задние фары


    private void Start()
    {
        carBodyColor.color = Color.yellow;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            light1.SetActive(true);
            carBodyColor.color = Color.white;
            lightButton.color = Color.green;
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            light1.SetActive(false);
            carBodyColor.color = Color.black;
            lightButton.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            light2.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            light2.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            light2.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            light2.SetActive(false);
        }
    }
}
