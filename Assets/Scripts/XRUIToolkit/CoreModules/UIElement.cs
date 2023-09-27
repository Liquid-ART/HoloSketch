using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace XRProtoUIToolKit
{

    public enum ElementsOrder
    {
        Default,
        Reversed,
        Random
    }

     [RequireComponent(typeof(IAnimationData_UI_Element))]
    public abstract class UIElementBase : MonoBehaviour, IUIElement
    {
        public ScreenManager ScreenManager { get; set; }
     //   protected IAnimatorGroup animatorGroup;
        public int ElementIndex { get; set; }



        [field: SerializeField]
        public bool IgnoreGroupEvents { get; set; }

        [field: SerializeField]
        public bool IsHiden { get; set; }

        [HideInInspector]
        public IAnimationData_UI_Element AnimationData_UI_Element;

       // private AnimationData animationData;

        public EventReciver eventReciever;


        public virtual void Init()
        {
            

            ScreenManager = GetComponentInParent<ScreenManager>();

            // animator_uiElement = (IUIElementAnimator)Object.Instantiate((Object)animator_uiElement);
            AnimationData_UI_Element = GetComponent<IAnimationData_UI_Element>();
            //animationData = (AnimationData)AnimationData_UI_Element;
            //AnimationData_UI_Element.Init(gameObject);
            if (ScreenManager == null) Debug.LogError("Group Manager == null on gameobject" + gameObject.name);
            if (AnimationData_UI_Element == null) Debug.LogError("animator_uiElement == null on gamobject: " + gameObject.name);
            UpdateHierarchyIndex();

            if (IsHiden) AnimationData_UI_Element.Show.SetDelay(0)
                        .PlayBackwards();

        }



        public virtual void UpdateHierarchyIndex()
        {
            ElementIndex = ScreenManager.GetUIElementArrayPosition(this);
        }



        public virtual void Hide(float delay)
        {
            Hide(delay, 1, false, ElementsOrder.Default, () => { });
            //AnimationData_UI_Element.Show.SetDelay(delay).PlayBackwards();
        }

        public virtual void HideLogic(float delay, float interval, bool sendForward, ElementsOrder elementsOrder, ScreenManagerCallback Callback, ITweenAnimation hideAnimation)
        {
            if (ScreenManager == null) Debug.Log("ScreenManager == null");
            int elementIndex = ScreenManager.GetUIElementArrayPosition(this);
            int elementsCount = ScreenManager.Elements.Length;
            IUIElement nextElemet;
            IsHiden = true;

            float nextElementDelay = delay + interval;

            if (elementsOrder == ElementsOrder.Default)
            {
                if (elementIndex > 0)
                {
                    nextElemet = ScreenManager.Elements[elementIndex - 1];

                    hideAnimation.SetDelay(delay)
                        .PlayBackwards();
                    if (sendForward)
                        nextElemet.Hide(nextElementDelay, interval, true, elementsOrder, Callback);
                }

                else
                {
                    hideAnimation.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay)
                        .PlayBackwards();
                }
            }

            if (elementsOrder == ElementsOrder.Reversed)
            {
                if (elementIndex < elementsCount - 1)
                {
                    hideAnimation.SetDelay(delay)
                        .PlayBackwards();
                    // if (elementIndex < elementsCount - 1 && sendForward)
                    // {
                    nextElemet = ScreenManager.Elements[elementIndex + 1];
                    nextElemet.Hide(nextElementDelay, interval, true, elementsOrder, Callback);
                    // }
                }

                else
                {
                    hideAnimation.OnComplete(() => {
                        Callback();


                    }).SetDelay(delay)
                        .PlayBackwards();
                }
            }

            if (elementsOrder == ElementsOrder.Random)
            {
                List<IUIElement> activeUIElements = new List<IUIElement>();
                foreach (var i in ScreenManager.Elements)
                {
                    if (!i.IsHiden)
                        activeUIElements.Add(i);
                }

                if (activeUIElements.Count > 0)
                {
                    hideAnimation.SetDelay(delay)
                        .PlayBackwards();

                    int nextElementIndex = Random.Range(0, activeUIElements.Count);
                    activeUIElements[nextElementIndex].Hide(nextElementDelay, interval, true, elementsOrder, Callback);
                }

                else
                {
                    hideAnimation.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay).PlayBackwards();
                }
            }
        }

        public virtual void Hide(float delay, float interval, bool sendForward, ElementsOrder elementsOrder, ScreenManagerCallback Callback)
        {
            HideLogic(delay, interval, sendForward, elementsOrder, Callback, AnimationData_UI_Element.Show);
           
           /* if (ScreenManager == null) Debug.Log("ScreenManager == null");
            int elementIndex = ScreenManager.GetUIElementArrayPosition(this); 
            int elementsCount = ScreenManager.Elements.Length; 
            IUIElement nextElemet;
            IsHiden = true;

            float nextElementDelay = delay + interval;

            if (elementsOrder == ElementsOrder.Default)
            {
                if (elementIndex > 0)
                {
                    nextElemet = ScreenManager.Elements[elementIndex - 1];

                    AnimationData_UI_Element.Show.SetDelay(delay)
                        .PlayBackwards();
                    if (sendForward)
                        nextElemet.Hide(nextElementDelay, interval, true, elementsOrder, Callback);
                }

                else
                {
                    AnimationData_UI_Element.Show.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay)
                        .PlayBackwards();
                }
            }

            if (elementsOrder == ElementsOrder.Reversed)
            {
                if (elementIndex < elementsCount - 1)
                {
                    AnimationData_UI_Element.Show.SetDelay(delay)
                        .PlayBackwards();
                   // if (elementIndex < elementsCount - 1 && sendForward)
                   // {
                        nextElemet = ScreenManager.Elements[elementIndex + 1];
                        nextElemet.Hide(nextElementDelay, interval, true, elementsOrder, Callback);
                   // }
                }

                else
                {
                    AnimationData_UI_Element.Show.OnComplete(() => {
                        Callback();


                    }).SetDelay(delay)
                        .PlayBackwards();
                }
            }

            if(elementsOrder == ElementsOrder.Random)
            {
                List<IUIElement> activeUIElements = new List<IUIElement>();
                foreach (var i in ScreenManager.Elements)
                {
                    if (!i.IsHiden)
                        activeUIElements.Add(i);
                }

                if (activeUIElements.Count > 0)
                {
                    AnimationData_UI_Element.Show.SetDelay(delay)
                        .PlayBackwards();

                    int nextElementIndex = Random.Range(0, activeUIElements.Count);
                    activeUIElements[nextElementIndex].Hide(nextElementDelay, interval, true, elementsOrder, Callback);
                }

                else
                {
                    AnimationData_UI_Element.Show.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay).PlayBackwards();
                }
            }*/

        }




        public virtual void Show(float delay)
        {
            //AnimationData_UI_Element.Show.SetDelay(delay).Play();
            Show(delay, 1, false, ElementsOrder.Default, () => { });
        }

        public virtual void ShowLogic(float delay, float interval, bool sendForward, ElementsOrder elementsOrder, ScreenManagerCallback Callback, ITweenAnimation showAnimation)
        {
            int elementIndex = ScreenManager.GetUIElementArrayPosition(this);
            int elementsCount = ScreenManager.Elements.Length;
            IsHiden = false;
            IUIElement nextElemet;

            float nextElementDelay = delay + interval;

            if (elementsOrder == ElementsOrder.Default)
            {
                if (elementIndex < elementsCount - 1)
                {
                    showAnimation.SetDelay(delay)
                        .Play();

                    if (sendForward)
                    {
                        nextElemet = ScreenManager.Elements[elementIndex + 1];
                        nextElemet.Show(nextElementDelay, interval, true, elementsOrder, Callback);
                    }


                }

                else
                {
                    showAnimation.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay)
                        .Play();
                }

            }

            if (elementsOrder == ElementsOrder.Reversed)
            {

                if (elementIndex > 0)
                {
                    nextElemet = ScreenManager.Elements[elementIndex - 1];

                    showAnimation.SetDelay(delay)
                        .Play();
                    if (sendForward)
                        nextElemet.Show(nextElementDelay, interval, true, elementsOrder, Callback);
                }

                else
                {
                    showAnimation.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay)
                        .Play();
                }
            }

            if (elementsOrder == ElementsOrder.Random)
            {
                Debug.Log("Run ElementsOrder.Random");
                List<IUIElement> hidenUIElements = new List<IUIElement>();
                foreach (var i in ScreenManager.Elements)
                {
                    if (i.IsHiden)
                        hidenUIElements.Add(i);
                }

                if (hidenUIElements.Count > 0)
                {
                    showAnimation.SetDelay(delay)
                        .Play();

                    int nextElementIndex = Random.Range(0, hidenUIElements.Count);
                    hidenUIElements[nextElementIndex].Show(nextElementDelay, interval, true, elementsOrder, Callback);
                }

                else
                {
                    showAnimation.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay).Play();
                }
            }
        }

        public virtual void Show(float delay, float interval, bool sendForward, ElementsOrder elementsOrder, ScreenManagerCallback Callback)
        {

            ShowLogic(delay, interval, sendForward, elementsOrder, Callback, AnimationData_UI_Element.Show);

          /* int elementIndex = ScreenManager.GetUIElementArrayPosition(this);
           int elementsCount = ScreenManager.Elements.Length;
            IsHiden = false;
            IUIElement nextElemet;

            float nextElementDelay = delay + interval;

            if (elementsOrder == ElementsOrder.Default)
            {
                if (elementIndex < elementsCount - 1)
                {
                    AnimationData_UI_Element.Show.SetDelay(delay)
                        .Play();

                    if (sendForward)
                    {
                        nextElemet = ScreenManager.Elements[elementIndex + 1];
                        nextElemet.Show(nextElementDelay, interval, true, elementsOrder, Callback);
                    }


                }

                else
                {
                    AnimationData_UI_Element.Show.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay)
                        .Play();
                }

            }

            if (elementsOrder == ElementsOrder.Reversed)
            {

                if (elementIndex > 0)
                {
                    nextElemet = ScreenManager.Elements[elementIndex - 1];

                    AnimationData_UI_Element.Show.SetDelay(delay)
                        .Play();
                    if (sendForward)
                        nextElemet.Show(nextElementDelay, interval, true, elementsOrder, Callback);
                }

                else
                {
                    AnimationData_UI_Element.Show.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay)
                        .Play();
                }
            }

            if (elementsOrder == ElementsOrder.Random)
            {
                Debug.Log("Run ElementsOrder.Random");
                List<IUIElement> hidenUIElements = new List<IUIElement>();
                foreach (var i in ScreenManager.Elements)
                {
                    if (i.IsHiden)
                        hidenUIElements.Add(i);
                }

                if (hidenUIElements.Count > 0)
                {
                    AnimationData_UI_Element.Show.SetDelay(delay)
                        .Play();

                    int nextElementIndex = Random.Range(0, hidenUIElements.Count);
                    hidenUIElements[nextElementIndex].Show(nextElementDelay, interval, true, elementsOrder, Callback);
                }

                else
                {
                    AnimationData_UI_Element.Show.OnComplete(() => {

                        Callback();

                    }).SetDelay(delay).Play();
                }
            }*/


        /*  if (elementIndex < elementsCount)
          {

              float nextElementDelay = delay + interval;

              animator_uiElement.SetVisible.SetDelay(delay).Play();

              if(elementIndex < elementsCount - 1 && sendForward)
              {
                  nextElemet = GroupManager.Elements[elementIndex + 1];
                  nextElemet.Show(nextElementDelay, interval, true);
              }

          }*/

    }

    }

    public class UIElement : UIElementBase, IUIElement
    {
        public void OnEnable()
        {
            eventReciever = new EventReciver();
            eventReciever.Init(this);

        }

        private bool isInitialised_ignoreGroupEvents = false;
        void LateUpdate()
        {
            if (IgnoreGroupEvents && !isInitialised_ignoreGroupEvents)
            {
                Init();
                isInitialised_ignoreGroupEvents = true;
            }

        }
    }
}
