using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRProtoUIToolKit
{
    public class DefaultScreenManager : ScreenManager
    {
        void Start()
        {
            Init();
        }
        public override void Show()
        {
            base.Show();
            Debug.Log("Show " + gameObject.name);
        }
    }
}

