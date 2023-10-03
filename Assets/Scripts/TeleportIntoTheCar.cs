using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportIntoTheCar : MonoBehaviour
{
    public GameObject player;

    public void TeleportInCar()
    {
        player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
