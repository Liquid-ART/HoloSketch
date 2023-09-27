

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRProtoUIToolKit
{

    public interface ICheckbox
    {
        bool IsSelected { get; set; }
    }

    [RequireComponent(typeof(IAnimationData_CheckBox))]
    public class Checkbox : InteractableElement, ICheckbox
    {
        [field: SerializeField]
        public bool IsSelected { get; set; }

        private IAnimationData_CheckBox cbAnimData;

        public override void Init()
        {
            base.Init();
            if (!typeof(IAnimationData_CheckBox).IsAssignableFrom(AnimationData_InteractableElement.GetType()))
                Debug.LogError("Checkbox has wrong IAnimationData assigned. On gameobject: " + gameObject.name);
            cbAnimData = (IAnimationData_CheckBox)AnimationData_InteractableElement;

            if (!IsSelected)
                cbAnimData.Press.PlayBackwards(); 

            else
                cbAnimData.Press.Play();
            

        }


        public override void OnPointerEnter()
        {
            if (IsLocked) return;

            if (!IsSelected)
                cbAnimData.Hover.Play();
            else
                cbAnimData.HoverSelected.Play();
            
            if (IEdepended.Length > 0)
            {
                foreach (var i in IEdepended)
                {
                    i.OnPointerEnter();
                }
            }

            if (showTooltip == ShowTooltip.OnHover)
                tooltip.Show(1);
        }

        public override void OnPointerExit()
        {

            if (IsLocked) return;

            if (!IsSelected)
            {
                cbAnimData.Hover.PlayBackwards();
            }

            else
            {
                cbAnimData.HoverSelected.PlayBackwards();
            }

            if (showTooltip == ShowTooltip.OnHover)
                tooltip.Hide(0);
        }

        public override void OnPointerUp()
        {

        }

        public virtual void ProcessCheck()
        {
            if (IsLocked) return;

            if (!IsSelected)
            {
                 Debug.Log("Checkbox Click !IsSelected" + gameObject.name);

                cbAnimData.Press.Play();
                IsSelected = true;

            }

            else
            {

                cbAnimData.Press.PlayBackwards();
                IsSelected = false;

            }


        }

        public override void OnPointerClick()
        {
            if (IsLocked) return;

            ProcessCheck();
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


    }
}



