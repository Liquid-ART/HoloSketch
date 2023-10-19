using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Core;
using UltimateXR.Locomotion;
using UltimateXR.Devices;
using UltimateXR.Avatar;
using UltimateXR.Extensions.Unity;

public class SlidesSwitcher : MonoBehaviour
{

    public GameObject[] screens;
    int currentScreen = 0;
    public GameObject Env, Sphere;
    public int SwitchIndex = 2;
    public bool HasEnv = false;

    public GameObject[] switchables;

    //public SteamVR_Input_Sources RightController, LeftController;
   // public SteamVR_Action_Boolean Trigger;

    //private SteamVR_Behaviour_Pose pose;

    void Awake()
    {
       // pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void RightTriggerDown()
    {
        currentScreen = /*Mathf.Clamp((currentScreen + 1), 0 , (screens.Length - 1));*/Mathf.Abs((currentScreen + 1) % (screens.Length));
        Debug.Log("currentScreen " + currentScreen);
        foreach (var i in screens)
        {
            i.SetActive(false);

        }
        screens[currentScreen].SetActive(true);
    }

    private void LeftTriggerDown()
    {
        if (currentScreen == 0)
            currentScreen = screens.Length - 1;
        else
            currentScreen = /*Mathf.Clamp((currentScreen + 1), 0 , (screens.Length - 1));*/Mathf.Abs((currentScreen - 1) % (screens.Length));

        Debug.Log("currentScreen " + currentScreen);
        foreach (var i in screens)
        {
            i.SetActive(false);

        }
        screens[currentScreen].SetActive(true);
        Debug.Log("currentScreen " + currentScreen);
    }


    void SwitchEnv()
    {
        foreach (var i in switchables)
        {
            if (screens[currentScreen].GetComponent<SlideEnv>().env == i)
                i.SetActive(true);
            else
                i.SetActive(false);
        }
        
        

        /*if (currentScreen == (SwitchIndex - 1)) //show env
        {
            Env.SetActive(false);
            Sphere.SetActive(true);
        }
        else if (currentScreen != (SwitchIndex - 1) ) //hide env
        {
            Env.SetActive(true);
            Sphere.SetActive(false);

        }*/
    }


    public UxrAvatar Avatar;
    


    void Update()
    {
        Vector2 input = Avatar.ControllerInput.GetInput2D(UxrHandSide.Left, UxrInput2D.Joystick);


        if (/*input.x > 0.5f*/Avatar.ControllerInput.GetButtonsPressDown(UxrHandSide.Left, UxrInputButtons.DPadRight))
        {

            RightTriggerDown();
            if(HasEnv) SwitchEnv();
        }

        if (Avatar.ControllerInput.GetButtonsPressDown(UxrHandSide.Left, UxrInputButtons.DPadLeft))
        {

            LeftTriggerDown();
            if(HasEnv) SwitchEnv();
        }
    }
}
