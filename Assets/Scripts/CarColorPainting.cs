using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColorPainting : MonoBehaviour
{
    public Material carColor;

    public void REDColor()
    {
        carColor.color = Color.red;
    }

    public void GREENColor()
    {
        carColor.color = Color.green;
    }

    public void BLUEColor()
    {
        carColor.color = Color.blue;
    }

    public void YELLOWColor()
    {
        carColor.color = Color.yellow;
    }

    public void WHITEColor()
    {
        carColor.color = Color.white;
    }

    public void BLACKColor()
    {
        carColor.color = Color.black;
    }

    public void MAGENTAColor()
    {
        carColor.color = Color.magenta;
    }

    public void GREYColor()
    {
        carColor.color = Color.grey;
    }

}
