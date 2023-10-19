using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using OculusSampleFramework;
using Oculus;

using UltimateXR.Avatar;
using UltimateXR.Devices;
using UltimateXR.Core;
//using Valve.VR;


public class VRInputModule : BaseInputModule
{

    public Camera m_Camera;
  //  public SteamVR_Input_Sources m_TargetSource;
   // public SteamVR_Action_Boolean m_ClickAction;

    //[SerializeField] private InputActionAsset oculusInputActions;
   // private InputActionMap oculusControllerInputMap;

    private GameObject m_CurrentObject = null;
    public PointerEventData m_Data = null;

    protected override void Awake()
    {
        // print("AWAKE");
      //  oculusControllerInputMap = oculusInputActions.FindActionMap("OculusControllerInput");

        base.Awake();
        m_Data = new PointerEventData(eventSystem);
    }

    bool TriggerPressed;
    public override void Process()
    {
       // print("PROCESS");
        //Reset data and set camera
        //
        m_Data.Reset();
        m_Data.position = new Vector2(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2);
        // Raycast
        eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
        m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        m_CurrentObject = m_Data.pointerCurrentRaycast.gameObject;
        // Clear
        m_RaycastResultCache.Clear();
        //Hover
        HandlePointerExitAndEnter(m_Data, m_CurrentObject);
        // print(m_Data.selectedObject);

        // Press
        // if (UxrAvatar.LocalAvatarInput.GetButtonsEvent(UxrHandSide.Right, UxrInputButtons.Trigger, UxrButtonEventType.PressDown))
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))

        {
            TriggerPressed = true;
            if (!m_Data.used)
            {
                Debug.Log("VR Input Click");
                ProcessPress(m_Data);
                m_Data.Use();
            }

        }

        // Release input
        if (!OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && TriggerPressed == true)
        {
            TriggerPressed = false;
            ProcessRelease(m_Data);
        }

    }

    public PointerEventData GetData()
    {
       // print("GET_DATA");
        return m_Data;
    }

    private void ProcessPress(PointerEventData data)
    {
        // Set raycest


        data.pointerPressRaycast = data.pointerCurrentRaycast;

        // Check for object hit, get the down handler and call it
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(m_CurrentObject, data, ExecuteEvents.pointerDownHandler);

        // if no down handler check for a click handler
        if (newPointerPress == null)
        {
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);
        }

       // Debug.Log("Process Press " + newPointerPress.name);
        // Set data
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = m_CurrentObject;
    }

    private void ProcessRelease(PointerEventData data)
    {
        // Execute pointer up

         

        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        // Check for click handler

        GameObject pointUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);

        // Check if actual
        if (data.pointerPress == pointUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        // Clear the selected game object
        eventSystem.SetSelectedGameObject(null);

        // Reset data
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;



    }



}
