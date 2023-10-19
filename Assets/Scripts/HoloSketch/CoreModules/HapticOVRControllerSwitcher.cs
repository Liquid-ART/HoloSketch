using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloSketch;

public class HapticOVRControllerSwitcher : MonoBehaviour

{
    public GameObject RightController, LeftController;



    public HapticManagerOVRdirectIntercation hapticManager;

    public void OnTriggerEnter(Collider other)
    {

       // Debug.Log("COLLISION HapticOVRControllerSwitcher " + other.name);
        if (other.gameObject == RightController)
        {
            hapticManager.RightControllerActive = true;
           // Debug.Log("---RightController");
        }

        else if (other.gameObject == LeftController)
        {
            hapticManager.RightControllerActive = false;
           // Debug.Log("---LeftController");
        }

    }
}
