using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

namespace XRProtoUIToolKit
{
    public class SelectContent : ScreenManager
    {
        public Select select;
        private RadioButton[] radioButtons;

        void Start()
        {
            Init();
            radioButtons = GetComponentsInChildren<RadioButton>();
            //ContentScreenManager.OnHideSelects += HideSelectContent; ! it was a static event
        }
        public void HideSelectContent(InteractableElement sender)
        {
            if (IsActive && sender != select) {
                select.ProcessCheck(); select.OnPointerExit();
                Hide(() => { Debug.Log("HIDE select.ProcessCheck();"); });
            }

        }

        public override void ExecuteAction(UnityEngine.Object sender)
        {
            InteractableElement senderInteractable = (InteractableElement)sender;
           //  GameObject obj = (GameObject)sender;
            TextMeshProUGUI text = senderInteractable.GetComponentInChildren<TextMeshProUGUI>();
            string value = text.text;
            select.UpdateValue(value);
            select.ProcessCheck(); select.OnPointerExit();
            Hide(0.5f, 0,() => {  });

            foreach (var i in radioButtons)
            {
                if(i.IsSelected) i.AnimationData_InteractableElement.Hover.PlayBackwards();
            }
        }

        private void OnDestroy()
        {
            //ContentScreenManager.OnHideSelects -= HideSelectContent;
        }
    }
}

