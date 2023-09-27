using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using TMPro;

namespace XRProtoUIToolKit
{

    public abstract class ScreenManager : MonoBehaviour, IScreenManager
    {

        [HideInInspector]
        public Transform Transform { get; set; }
        [HideInInspector]
        public IUIElement[] Elements { get; set; }

        [SerializeField]
        protected float elemetsShowInterval = 0.3f;
        [SerializeField]
        protected float elementsShowDelay = 0f;

        [SerializeField]
        protected float elementsHideInterval = 0.1f;
        [SerializeField]
        protected float elementsHideDelay = 0f;


        [field: SerializeField]
        public bool IsActive { get; set; }





        private int randomElementIndex = 0;
        private bool randomElementIndexIsGenereated = false;


        public ElementsOrder ElementsOrder = ElementsOrder.Default;
        public int StartRandomElementIndex { get {
                int index = randomElementIndex;
                if (!randomElementIndexIsGenereated)
                {
                    index = UnityEngine.Random.Range(0, Elements.Length);
                    randomElementIndexIsGenereated = true;
                }
                return index;
            } }


        [Header("Group animation"), Space, SerializeField]
        protected bool useGroupAnimation;
        public bool hideScreenAfterElements = false;
        public bool showElemetsAfterScreen = false;

        [SerializeField]
        protected IAnimationData_Screen screenAnimationData;
        [SerializeField]
        protected float openAnimDelay = 0, openAnimDuration = 0.3f;
        [SerializeField]
        protected float closeAnimDelay = 0, closeAnimDuration = 0.3f;

        [HideInInspector]
        public ScreenEventManager eventManager;

    /*    public void Awake()
        {
            eventManager = new ScreenEventManager();
            eventManager.Init(this);
            Debug.Log("eventManager.Init(this);");
        }*/

        public virtual void Init()
        {
            screenAnimationData = GetComponent<IAnimationData_Screen>();

            if (useGroupAnimation)
            {
                if (screenAnimationData == null)
                {
                    Debug.LogError("Group Animation is Not Assigned at obj " + gameObject.name + " while useGroupAnimation == true");
                    useGroupAnimation = false;
                    return;
                }

                screenAnimationData.Show.Init(gameObject);
            }

            List<IUIElement> uiElementsCash = GetComponentsInChildren<IUIElement>().ToList();
            List<IUIElement> uiElementsCashFiltered = new List<IUIElement>();

            foreach (var i in uiElementsCash)
            {
                if (!i.IgnoreGroupEvents)
                    uiElementsCashFiltered.Add(i);
            }

            Elements = uiElementsCashFiltered.ToArray();



            eventManager = GetComponent<ScreenEventManager>();
            Transform = transform;
            eventManager.InitGroup();
           // Debug.Log(" InitGroup() is called. Obj: " + gameObject.name);

            if (!IsActive)
                Hide();



        }

        bool firstFrameRunned = false;
       /* public virtual void Update()
        {

            if (!firstFrameRunned)
            {
                firstFrameRunned = true;
                if (!IsActive)
                    Hide();
            }

        }*/

        public virtual void ExecuteAction(UnityEngine.Object sender)
        {
            
        }

        public virtual void ClickAction(UnityEngine.Object sender, string expectedName, ActionCallback Callback)
        {
                Debug.Log("ClickAction: " + sender.name + " GroupManagerObj:" + gameObject.name);
                InteractableElement interactable = (InteractableElement)sender;

                if (interactable.gameObject.name == expectedName)
                {
                    Callback();
                }

            
        }


        public virtual void Hide()
        {
            Hide(elementsHideDelay, elementsHideInterval, ElementsOrder, () => { });
        }

        public virtual void Hide(ScreenManagerCallback Callback)
        {
            Hide(elementsHideDelay, elementsHideInterval, ElementsOrder, () => { Callback(); }); 
        }

        public virtual void Hide(ElementsOrder _elementsOrder)
        {
            Hide(elementsHideDelay, elementsHideInterval, _elementsOrder, () => { });
        }

        public virtual void Hide(ElementsOrder _elementsOrder, ScreenManagerCallback Сallback)
        {
            Hide(elementsHideDelay, elementsHideInterval, _elementsOrder, Сallback);
        }

        public virtual void Hide(float delay, float interval)
        {
            Hide(delay, interval, ElementsOrder, () => { });
        }

        public virtual void Hide(float delay, float interval, ScreenManagerCallback Сallback)
        {
            Hide(delay, interval, ElementsOrder, Сallback);
        }

        public virtual void Hide(float delay, float interval, ElementsOrder _elementsOrder)
        {
            Hide(delay, interval, _elementsOrder, () => { });
        }

        public virtual void Hide(float delay, float interval, ElementsOrder _elementsOrder, ScreenManagerCallback Сallback)
        {
            IsActive = false;

            if(hideScreenAfterElements && useGroupAnimation)

                eventManager.HideGroup(delay, interval, _elementsOrder, () => {
                    screenAnimationData.Show.SetDelay(closeAnimDelay).SetDuration(closeAnimDuration).PlayBackwards();
                }); 

            else if (useGroupAnimation)
            {
                eventManager.HideGroup(delay, interval, _elementsOrder, Сallback);
                screenAnimationData.Show.SetDelay(closeAnimDelay).SetDuration(closeAnimDuration).PlayBackwards();
            }

            else
            {
                eventManager.HideGroup(delay, interval, _elementsOrder, Сallback);
            }

        }






        public virtual void Show()
        {
            Show(elementsShowDelay, elemetsShowInterval, ElementsOrder, () => { });
        }


        public virtual void Show(ScreenManagerCallback Callback)
        {
            Show(elementsShowDelay, elemetsShowInterval, ElementsOrder, Callback);
        }

        public virtual void Show(ElementsOrder _elementsOrder)
        {
            Show(elementsShowDelay, elemetsShowInterval, _elementsOrder, () => { });
        }

        public virtual void Show(ElementsOrder elementsOrder, ScreenManagerCallback Сallback)
        {
            Show(elementsShowDelay, elemetsShowInterval, elementsOrder, Сallback);
        }

        public virtual void Show(float delay, float interval)
        {
            Show(delay, interval, ElementsOrder.Default, () => { });
        }

        public virtual void Show(float delay, float interval, ScreenManagerCallback Сallback)
        {
            Show(delay, interval, ElementsOrder.Default, Сallback);
        }

        public virtual void Show(float delay, float interval, ElementsOrder _elementsOrder)
        {
            Show(delay, interval, _elementsOrder, () => { });
        }

        public virtual void Show(float delay, float interval, ElementsOrder _elementsOrder, ScreenManagerCallback Сallback)
        {
            IsActive = true;

            if (showElemetsAfterScreen && useGroupAnimation)
                screenAnimationData.Show.SetDelay(closeAnimDelay).SetDuration(closeAnimDuration).OnComplete(() => {
                    eventManager.ShowGroup(delay, interval, _elementsOrder, Сallback);
                }).Play();

            else if (useGroupAnimation)
            {
                eventManager.ShowGroup(delay, interval, _elementsOrder, Сallback);
                screenAnimationData.Show.SetDelay(closeAnimDelay).SetDuration(closeAnimDuration).Play();
            }

            else
            {
                eventManager.ShowGroup(delay, interval, _elementsOrder, Сallback);
            }



          /*  IsActive = true;
            eventManager.ShowGroup(delay, duration, _elementsOrder, Сallback);

            if (useGroupAnimation)
                screenAnimationData.Show.SetDelay(closeAnimDelay).SetDuration(closeAnimDuration).Play();*/
        }




        public virtual int GetUIElementArrayPosition(IUIElement element)
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                if (Elements[i] == element)
                    return i;
            }

            return 0;

        }

        public virtual void Disable()
        {
            eventManager.Disable();
        }

        public virtual void Enable()
        {
            eventManager.Enable();
        }

        public virtual void DisableInteraction()
        {
            eventManager.DisableInteraction();
        }

        public virtual void EnableInteraction()
        {
            eventManager.EnableInteraction();
        }

    }
}
