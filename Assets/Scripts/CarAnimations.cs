using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimations : MonoBehaviour
{
    public Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

        // анимации открытия (капот, багажник, двери)
    public void OpenCapot()
    {
        anim.Play("OpenCapot");
    }

    public void OpenTrunk()
    {
        anim.Play("OpenTrunk");
    }

    public void OpenLFDoor()
    {
        anim.Play("OpenLFDoor");
    }

    public void OpenLBDoor()
    {
        anim.Play("OpenLBDoor");
    }

    public void OpenRFDoor()
    {
        anim.Play("OpenRFDoor");
    }

    public void OpenRBDoor()
    {
        anim.Play("OpenRBDoor");
    }

    // анимации закрытия (капот, багажник, двери)
    public void CloseCapot()
    {
        anim.Play("CloseCapot");
    }

    public void CloseTrunk()
    {
        anim.Play("CloseTrunk");
    }

    public void CloseLFDoor()
    {
        anim.Play("CloseLFDoor");
    }

    public void CloseLBDoor()
    {
        anim.Play("CloseLBDoor");
    }

    public void CloseRFDoor()
    {
        anim.Play("CloseRFDoor");
    }

    public void CloseRBDoor()
    {
        anim.Play("CloseRBDoor");
    }
}
