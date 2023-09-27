using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XRProtoUIToolKit;

[CustomEditor(typeof(XRProtoUIToolKit.InteractableElement), true)]
public class InteractableElementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        base.OnInspectorGUI();
        InteractableElement script = (InteractableElement)target;

        if (GUILayout.Button("OnPointerEnter"))
            script.OnPointerEnter();

        if (GUILayout.Button("OnPointerExit"))
            script.OnPointerExit();

        if (GUILayout.Button("OnPointerDown"))
            script.OnPointerDown();

        if (GUILayout.Button("OnPointerUp"))
            script.OnPointerUp();

        if (GUILayout.Button("OnClick"))
        {
            script.OnPointerClick();
            Debug.Log(" if (GUILayout.Button(OnClick))");
        }

        if (GUILayout.Button("Lock"))
            script.Lock();

        if (GUILayout.Button("UnLock"))
            script.Unlock();

        if (GUILayout.Button("Show"))
            script.Show(0);
        if(GUILayout.Button("Hide"))
            script.Hide(0);
    }
}
