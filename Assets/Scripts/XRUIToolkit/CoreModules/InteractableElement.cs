using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

namespace XRProtoUIToolKit
{
    public enum ShowTooltip
    {
        None,
        OnHover,
        OnPress
    }

    public abstract class InteractableElement : UIElementBase, IInteractableElement
    {
       // [field: SerializeField]
        public bool DisabledInPrototype { get; private set; }//как отключить остальную логику? через EventReciver? Не подключать Input handler?

        [field: SerializeField]
        public bool IsLocked { get; set; }

        [HideInInspector]
        public bool IsPointerDown;

        public IAnimationData_InteractableElement AnimationData_InteractableElement;

        protected IUIElement uiElement;
        protected IInputHandler[] inputHandlers;
        protected IInteractableElementDepended[] IEdepended;

        [HideInInspector]
        public EventReciverInteractableElement eventReciverInteractable;

       // public KeyCode ClickByKey = KeyCode.None;
     //  public XRProtoUIToolKitInputActions keyInputActions;
      //  public InputS

        [Space]
        public ShowTooltip showTooltip = ShowTooltip.None;
        public UIElementBase tooltip;

        public void OnEnable()
        {
         //   keyInputActions = new XRProtoUIToolKitInputActions();
          //  keyInputActions.Enable();

            eventReciverInteractable = new EventReciverInteractableElement();
            eventReciverInteractable.Init(this);
        }

        public void OnDisable()
        {
           // keyInputActions.Disable();
        }



        /*public virtual void Update()
        {
            if (Input.GetKeyDown(ClickByKey))
            {
                OnPointerClick();
                Debug.Log("ClickByKeycode " + gameObject.name);
            }
        }*/

        public override void Init()
         {

            base.Init();
            inputHandlers = GetComponents<IInputHandler>();
            if (inputHandlers.Length > 0)
            {
                foreach (var i in inputHandlers)
                {
                    i.Init();
                }
            }
            else
                Debug.LogError("No Input Handler is Assigned. Obj: " + gameObject.name);

            /*  
              animator_InteractableElement = (IIEAnimator)Instantiate((Object)animator_InteractableElement);//создаем отдельный обьект во избежание изменений*/
            AnimationData_InteractableElement = GetComponent<IAnimationData_InteractableElement>(); 
           // AnimationData_InteractableElement.Init(gameObject);



             IEdepended = GetComponentsInParent<IInteractableElementDepended>();

            if (IsLocked)
            {
                Lock();
            }

          //  animator_InteractableElement.Hover.PlayBackwards();

            //Debug.Log("INit IE " + gameObject.name);
            // audioManager = GetComponentInParent<AudioManager>();

        }


        public virtual void OnPointerEnter()
        {        
            AnimationData_InteractableElement.Hover.Play();

            if(IEdepended.Length > 0)
            {
                foreach (var i in IEdepended)
                {
                    i.OnPointerEnter();
                }
            }

            if (showTooltip == ShowTooltip.OnHover)
                tooltip.Show(1);


        }

        public virtual void OnPointerExit()
        {
            AnimationData_InteractableElement.Hover.SetDelay(0.2f).PlayBackwards();
            if (showTooltip == ShowTooltip.OnHover)
                tooltip.Hide(0);
        }

        public virtual void OnPointerClick()
        {

            ScreenManager.ExecuteAction(this);
            if (IEdepended.Length > 0)
            {
                foreach (var i in IEdepended)
                {
                    i.OnPointerClick();
                }
            }

            if (showTooltip == ShowTooltip.OnHover)
                tooltip.Hide(0);

        }

        public virtual void OnPointerDown()
        {
            AnimationData_InteractableElement.Press.Play();
            IsPointerDown = true;
            if (showTooltip == ShowTooltip.OnPress)
                tooltip.Show(0);
        }

        public virtual void OnPointerUp()
        {
            AnimationData_InteractableElement.Press.PlayBackwards();
            IsPointerDown = false;
            if (showTooltip == ShowTooltip.OnPress)
                tooltip.Hide(0);
        }

        public virtual void Unlock()
        {
            AnimationData_InteractableElement.Block.PlayBackwards();
            IsLocked = false;
            SetInteractionUnlocked();
        }

        public virtual void Lock()
        {
            IsLocked = true;
            SetInteractionLocked();
            AnimationData_InteractableElement.Block.Play();
        }

        public virtual void SetInteractionLocked()
        {
            foreach(var i in inputHandlers)
            {
                i.SetInteractionLocked();
            }
        }

        public virtual void SetInteractionUnlocked()
        {
            foreach (var i in inputHandlers)
            {
                i.SetInteractionUnlocked();
            }
        }

        public override void Hide(float delay, float interval, bool sendForward, ElementsOrder elementsOrder, ScreenManagerCallback Callback)
        {
            base.Hide(delay, interval, sendForward, elementsOrder, Callback);
            SetInteractionLocked();
        }

        public override void Show(float delay, float interval, bool sendForward, ElementsOrder elementsOrder, ScreenManagerCallback Callback)
        {
            base.Show(delay, interval, sendForward, elementsOrder, Callback);
            if(!IsLocked)
                SetInteractionUnlocked();
        }

        public virtual void SetDisabledInPrototype()
        {

        }


    }
}
