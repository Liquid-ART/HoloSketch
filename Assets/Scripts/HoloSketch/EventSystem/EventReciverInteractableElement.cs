using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloSketch
{
    public class EventReciverInteractableElement : EventReciver
    {
        private InteractableElement interactableElement;


        public override void Init(IUIElement _uiElement)
        {
            base.Init(_uiElement);
            interactableElement = (InteractableElement)_uiElement;
           // if (interactableElement.IgnoreGroupEvents) return;
            eventManager.OnDisable += Lock;
            eventManager.OnEnable += Unlock;
            eventManager.OnDisableInteraction += DisableInteraction;
            eventManager.OnEnableInteraction += EnableInteraction;
            GlobalEventManager.OnDisableAllUiInteraction += DisableInteractionGlobal;
            GlobalEventManager.OnEnableAllUiInteraction += EnableInteraction;
        }


        void Lock()
        {
            interactableElement.Lock();
        }

        void DisableInteractionGlobal(bool IncludingCurrentlyInUse)
        {
            if(!IncludingCurrentlyInUse)
            {
                if (!interactableElement.IsPointerDown)
                {
                    DisableInteraction();
                }
            }

            else
            {
                    DisableInteraction();
            }

        }

        void Unlock()
        {
            interactableElement.Unlock();
        }

        void DisableInteraction()
        {
            if(!interactableElement.IsLocked)
            {
                interactableElement.OnPointerExit();
                interactableElement.SetInteractionLocked();
            }

        }

        void EnableInteraction()
        {
            interactableElement.SetInteractionUnlocked();
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
            eventManager.OnDisable -= Lock;
            eventManager.OnEnable -= Unlock;
            eventManager.OnDisableInteraction -= DisableInteraction;
            eventManager.OnEnableInteraction -= EnableInteraction;
            GlobalEventManager.OnDisableAllUiInteraction -= DisableInteractionGlobal;
            GlobalEventManager.OnEnableAllUiInteraction -= EnableInteraction;
        }

    }
}
