using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HoloSketch
{
    public static class GlobalEventManager 
    {
        public static event Action<bool> OnDisableAllUiInteraction;
        public static void DisableAllUiInteraction(bool includingCurrentlyInUse)
        {
            OnDisableAllUiInteraction?.Invoke(includingCurrentlyInUse);
            Debug.Log("DisableAllUiInteraction");
        }

        public static event Action OnEnableAllUiInteraction;
        public static void EnableAllUiInteraction()
        {
            Debug.Log("EnableAllUiInteraction");
            OnEnableAllUiInteraction?.Invoke();
        }
    }
}