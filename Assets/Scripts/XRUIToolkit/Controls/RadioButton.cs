using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRProtoUIToolKit
{

    public interface IRadioButton
    {
        bool IsSelected { get; set; }
        List<IRadioButton> RadioSiblings { get; set; }
        void Deselect();
        void Deselect(GenericCallback Callback);
        void Select();
        ScreenManager connectedScreen { get; set; }
    }
    
    public class RadioButton : InteractableElement, IRadioButton
    {
        [field: SerializeField]
        public bool IsSelected { get; set; }
        public List<IRadioButton> RadioSiblings { get; set; }

        [field: SerializeField]
        public ScreenManager connectedScreen { get; set; }

        public bool SwitchScreensSequentially = true;


        // if has connected screen then on select we find the radio that was previously selected
        // and then call hide screen with a callback which is invokes select animation
        // How the deselect animation is called? - call it but incer delay in select animation 

        public override void Init()
        {
            base.Init();
            IRadioButton[] radioSiblingsCash = transform.parent.GetComponentsInChildren<IRadioButton>();
            RadioSiblings = new List<IRadioButton>();

            if (!IsSelected)
                /*AnimationData_InteractableElement.Hover.Play().OnComplete(() => {*/ AnimationData_InteractableElement.Press.PlayBackwards(); /*});*/


            foreach (var i in radioSiblingsCash)
            {
                if (!ReferenceEquals(i, this))
                {
                    RadioSiblings.Add(i);
                }

            }

            if (IsSelected)
                AnimationData_InteractableElement.Press.Play();

            else
                AnimationData_InteractableElement.Press.PlayBackwards();
        }

        public override void OnPointerEnter()
        {
            if(!IsSelected)
                base.OnPointerEnter();
        }

        public override void OnPointerExit()
        {
            if (!IsSelected)
                base.OnPointerExit();
        }

        public override void OnPointerUp()
        {
            
        }

        public override void OnPointerClick()
        {
            Select();
            if (showTooltip == ShowTooltip.OnHover)
                tooltip.Hide(0);
        }

        public virtual void Select()
        {
            if (IsSelected) return;

            Debug.Log("Radio Select() is called");

            ScreenManager.ExecuteAction(this);

            if (IEdepended.Length > 0)
            {
                foreach (var i in IEdepended)
                {
                    i.OnPointerClick();
                }
            }

            if (connectedScreen == null)
            {
                AnimationData_InteractableElement.Press.Play();
 
                foreach (var i in RadioSiblings)
                {
                    i.Deselect();
                }

                IsSelected = true;
            }

            else 
            {


                foreach (var i in RadioSiblings)
                {
                    if (i.IsSelected)
                    {
                        if(SwitchScreensSequentially)
                        {
  
                            i.connectedScreen.Hide(() =>
                            {
                                connectedScreen.Show();
                                i.Deselect();
                                AnimationData_InteractableElement.Press.Play();
                            });
                        }

                        else
                        {
                            connectedScreen.Show();
                            i.connectedScreen.Hide(() =>
                            {
                                Debug.Log("----i.connectedScreen.Hide");
                                i.Deselect();
                                AnimationData_InteractableElement.Press.Play(); //connectedScreen.Show();
                                /*  i.Deselect(() => { Debug.Log("----i.Deselect(() => | Screen name" + connectedScreen.name + "   i.connectedScreen.name " + i.connectedScreen.name); 
                                      AnimationData_InteractableElement.Press.Play(); connectedScreen.Show(); }); */
                            });
                        }

                    }
                }

                IsSelected = true;
            }

        }

        public void Deselect()
        {

            if(IsSelected)
            {
                AnimationData_InteractableElement.Hover.PlayBackwards();
                IsSelected = false;
            }

        }

        public void Deselect(GenericCallback Callback)
        {


            if (IsSelected)
            {
                AnimationData_InteractableElement.Press.OnComplete(() => { Callback(); }).PlayBackwards();
                IsSelected = false;
            }

        }
    }
}

