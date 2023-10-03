using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWheels : MonoBehaviour
{
    public GameObject StockWheels;
    public GameObject DriftType1;
    public GameObject DriftType2;
    public GameObject DriftType3;
    public GameObject DriftType4;
    public GameObject DriftType5;

    private void Start()
    {
        StockWheels.SetActive(true);
        DriftType1.SetActive(false);
        DriftType2.SetActive(false);
        DriftType3.SetActive(false);
        DriftType4.SetActive(false);
        DriftType5.SetActive(false);
    }

    public void SelectStockWheels()
    {
        StockWheels.SetActive(true);
        DriftType1.SetActive(false);
        DriftType2.SetActive(false);
        DriftType3.SetActive(false);
        DriftType4.SetActive(false);
        DriftType5.SetActive(false);
    }

    public void SelectDriftType1()
    {
        StockWheels.SetActive(false);
        DriftType1.SetActive(true);
        DriftType2.SetActive(false);
        DriftType3.SetActive(false);
        DriftType4.SetActive(false);
        DriftType5.SetActive(false);
    }

    public void SelectDriftType2()
    {
        StockWheels.SetActive(false);
        DriftType1.SetActive(false);
        DriftType2.SetActive(true);
        DriftType3.SetActive(false);
        DriftType4.SetActive(false);
        DriftType5.SetActive(false);
    }

    public void SelectDriftType3()
    {
        StockWheels.SetActive(false);
        DriftType1.SetActive(false);
        DriftType2.SetActive(false);
        DriftType3.SetActive(true);
        DriftType4.SetActive(false);
        DriftType5.SetActive(false);
    }

    public void SelectDriftType4()
    {
        StockWheels.SetActive(false);
        DriftType1.SetActive(false);
        DriftType2.SetActive(false);
        DriftType3.SetActive(false);
        DriftType4.SetActive(true);
        DriftType5.SetActive(false);
    }

    public void SelectDriftType5()
    {
        StockWheels.SetActive(false);
        DriftType1.SetActive(false);
        DriftType2.SetActive(false);
        DriftType3.SetActive(false);
        DriftType4.SetActive(false);
        DriftType5.SetActive(true);
    }
}
