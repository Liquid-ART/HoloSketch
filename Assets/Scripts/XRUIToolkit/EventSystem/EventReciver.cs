using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRProtoUIToolKit
{
    public class EventReciver
    {
        protected ScreenManager screenManager;
        protected ScreenEventManager eventManager;
        protected UIElementBase uiElement;


        public virtual void Init(IUIElement _uiElement)
        {
           // Debug.Log(" EventReciver void Init(IUIElement _uiElement)");
            uiElement = (UIElementBase)_uiElement;
            //if (uiElement.IgnoreGroupEvents) return;

            screenManager = uiElement.GetComponentInParent<ScreenManager>();
            eventManager = screenManager.GetComponent<ScreenEventManager>();

            if(screenManager == null)
                Debug.Log(" EventReciver screenManager == null");

            if (eventManager == null)
                Debug.LogError("ScreenEventManager == null GameObject: " + uiElement.gameObject.name);

            eventManager.OnHideGroup += HideScreen;
            eventManager.OnShowGroup += ShowScreen;
            eventManager.OnInitGroup += InitGroup;
        }

        private void InitGroup()
        {
            //Event reciever mustbe  subcribed to the event before it is invoked
            //Curretly it's trying to subscribe in the Awake, but the screenEventManager isn't initialized at the moment
            //InitGroup is called in the Start function
            // still null - why? - broken execution order
            //
           // Debug.Log(" InitGroup() is recieved");
            uiElement.Init();
        } 

        private void HideScreen(float delay, float duration, ElementsOrder elementsOrder, ScreenManagerCallback Callback)
        {
            if (uiElement.IgnoreGroupEvents) return;
          //  Debug.Log("Hide group " + elementsOrder);
            uiElement.UpdateHierarchyIndex();

            if(elementsOrder == ElementsOrder.Default &&
                uiElement.ElementIndex == uiElement.ScreenManager.Elements.Length - 1)
            {
                    uiElement.Hide(delay, duration, true, elementsOrder, Callback);               
            }

            if(elementsOrder == ElementsOrder.Reversed &&
                uiElement.ElementIndex == 0)
            {
                uiElement.Hide(delay, duration, true, elementsOrder, Callback);
            }

            if(elementsOrder == ElementsOrder.Random && uiElement.ElementIndex == screenManager.StartRandomElementIndex)
            {
                bool oneOfElementsIsHiden = false;
                foreach (var i in screenManager.Elements)
                {
                    if (i.IsHiden)
                        oneOfElementsIsHiden = true;
                }
                if (oneOfElementsIsHiden) return;

                uiElement.Hide(delay, duration, true, elementsOrder, Callback);
            }
        }


        private void ShowScreen(float delay, float duration, ElementsOrder elementsOrder, ScreenManagerCallback Callback)
        {
            if (uiElement.IgnoreGroupEvents) return;

            uiElement.UpdateHierarchyIndex();

            if (elementsOrder == ElementsOrder.Default &&
                uiElement.ElementIndex == 0)
            {
                uiElement.Show(delay, duration, true, elementsOrder, Callback);
            }

            if (elementsOrder == ElementsOrder.Reversed &&
                uiElement.ElementIndex == uiElement.ScreenManager.Elements.Length - 1)
            {
                uiElement.Show(delay, duration, true, elementsOrder, Callback);
            }

            if (elementsOrder == ElementsOrder.Random && uiElement.ElementIndex == screenManager.StartRandomElementIndex)
            {
                bool oneOfElementsIsHiden = false;
                foreach (var i in screenManager.Elements)
                {
                    if (!i.IsHiden)
                        oneOfElementsIsHiden = true;
                }
                if (oneOfElementsIsHiden) return;
                Debug.Log("Show elementsOrder == ElementsOrder.Random");
                uiElement.Show(delay, duration, true, elementsOrder, Callback);
            }
            /*
            if (uiElement.ElementIndex == 0)
            {
               // uiElement.Show(delay, duration, true);
            }*/
        }

        protected void UnsubscribeFromEvents()
        {
            eventManager.OnInitGroup -= InitGroup;
            eventManager.OnHideGroup -= HideScreen;
            eventManager.OnShowGroup -= ShowScreen;
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }
    }
}
