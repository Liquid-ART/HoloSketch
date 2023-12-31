using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloSketch
{
    public class CheckboxPaired : Checkbox
    {
        [SerializeField]
        protected Checkbox pairedCheckbox;

        public override void OnPointerClick()
        {
            base.OnPointerClick();
            pairedCheckbox.ProcessCheck();
        }
    }
}

