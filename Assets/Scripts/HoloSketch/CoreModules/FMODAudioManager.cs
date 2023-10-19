using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using HoloSketch;

public class FMODAudioManager : MonoBehaviour, IAudioManager, IInteractableElementDepended
{
    public bool IsActive { get; set; }

    [SerializeField]
    private EventReference hoverSound, clickSound;


    public void PlayClickSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(clickSound, gameObject);
    }

    public void PlayHoverSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(hoverSound, gameObject);
    }

    public void OnPointerClick()
    {
        PlayClickSound();
    }

    public void OnPointerDown()
    {

    }

    public void OnPointerEnter()
    {
        PlayHoverSound();
    }

    public void OnPointerExit()
    {

    }

    public void OnPointerUp()
    {

    }



}
