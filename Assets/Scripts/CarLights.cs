using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    public GameObject ligths;
    public Material lightButtonMaterial;

    private void Start()
    {
        lightButtonMaterial.color = Color.red;
        ligths.SetActive(false);
    }



    public void EnableLights()
    {
        ligths.SetActive(true);
        lightButtonMaterial.color = Color.green;
    }
    
    public void DisableLights()
    {
        ligths.SetActive(false);
        lightButtonMaterial.color = Color.red;
    }
}
