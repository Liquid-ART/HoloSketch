using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HoloSketch
{
    public class ScreenEventManager : MonoBehaviour
    {
        public event Action<float, float, ElementsOrder, ScreenManagerCallback> OnHideGroup;

        public event Action<float, float, ElementsOrder, ScreenManagerCallback> OnShowGroup;
        public event Action OnInitGroup;
        public event Action OnDisableInteraction, OnEnableInteraction;
        public event Action OnDisable, OnEnable;


       /* private ScreenManager screenManager;
        public void Init(ScreenManager _screenManager)
        {
            screenManager = _screenManager;
        }*/



        public void InitGroup()
        {
            OnInitGroup?.Invoke();

            //Debug.Log("InitGroup()" + gameObject.name);
        }


        public void HideGroup(float delay, float duration, ElementsOrder elementsOrder, ScreenManagerCallback callback)
        {
            OnHideGroup?.Invoke(delay, duration, elementsOrder, callback);
        }


        public void ShowGroup(float delay, float duration, ElementsOrder elementsOrder, ScreenManagerCallback callback)
        {
            OnShowGroup?.Invoke(delay, duration, elementsOrder, callback);
        }

        public void Disable()
        {
            OnDisable?.Invoke();
        }

        public void Enable()
        {
            OnEnable?.Invoke();
        }

        public void DisableInteraction()
        {
            OnDisableInteraction?.Invoke();
        }

        public void EnableInteraction()
        {
            OnEnableInteraction?.Invoke();
        }


    }
}
