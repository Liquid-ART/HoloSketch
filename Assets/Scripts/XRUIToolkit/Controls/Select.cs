using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace XRProtoUIToolKit
{
    public class Select : Checkbox
    {
        public SelectContent selectContent;
        public TextMeshProUGUI textValue;
        private Select[] SelectSibligs;

        public override void Init()
        {
            base.Init();
            SelectSibligs = ScreenManager.GetComponentsInChildren<Select>();
        }

        public void UpdateValue(string value)
        {
            textValue.text = value;
        }

        public override void OnPointerClick()
        {
            if (IsLocked) return;

            base.OnPointerClick();
            if (IsSelected)
            {
                selectContent.Show();

            }

            

            if (!IsSelected)
            {
                selectContent.Hide();
            }
        }

        public override void Lock()
        {
            if(!IsSelected)
            {
                base.Lock();
            }
            else
            {
                IsLocked = true;
                IsSelected = false;
                SetInteractionLocked();

                AnimationData_InteractableElement.Press.OnComplete(() => {
                    AnimationData_InteractableElement.Block.Play();
                }).PlayBackwards();
            }


        }

    }
}

