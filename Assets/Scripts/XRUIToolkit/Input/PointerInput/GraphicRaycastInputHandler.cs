using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XRProtoUIToolKit
{
    public class GraphicRaycastInputHandler : MonoBehaviour, IInputHandler,
    IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {

        

        private IInteractableElement interactableElement;
        private ScreenEventManager groupEventHandler;

        //----
        private bool isPointerOnOtherElement, hoverChangedEventRecieved, isInHoverState;


        private Image targetGraphic;

        public void Init()
        {
            interactableElement = GetComponent<InteractableElement>();


            if(transform.TryGetComponent<Image>(out targetGraphic))
            {

            }
            else
            {
                targetGraphic = transform.GetChild(0).GetComponent<Image>();
            }

            //targetGraphic = GetComponent<Image>();
          //  Debug.Log("Init GR " + gameObject.name);
            if (targetGraphic == null) Debug.LogError("targetGraphic == null" + gameObject.name);
        }



        private bool isClicked;
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("OnPointerClick Obj:" + gameObject.name);
            if (!isClicked)
                if (targetGraphic.raycastTarget)
                {
                    isClicked = true;
                    interactableElement.OnPointerClick();
                }

                else
                    isClicked = false;
        }

        bool lockTest;
        void LateUpdate()
        {
            if (targetGraphic == null && !lockTest) { lockTest = true; Debug.LogError("targetGraphic == null in Late Update. No Group Manager sent an event? GameObject: " + gameObject.name); }

            if (isClicked)
            {
                isClicked = false;
            }
        }



        public void OnPointerDown(PointerEventData eventData)
        {
            if (targetGraphic.raycastTarget)
                interactableElement.OnPointerDown();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
           // Debug.Log("OnPointerEnter " + gameObject.name);
            if (targetGraphic == null) Debug.Log("targetGraphic == null");
            if (targetGraphic.raycastTarget)
               interactableElement.OnPointerEnter();
            

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (targetGraphic.raycastTarget)
                interactableElement.OnPointerExit();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (targetGraphic.raycastTarget)
                interactableElement.OnPointerUp();
        }

        public void SetInteractionLocked()
        {
            targetGraphic.raycastTarget = false;
        }

        public void SetInteractionUnlocked()
        {
            targetGraphic.raycastTarget = true;

        }






    }
}