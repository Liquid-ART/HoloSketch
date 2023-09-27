

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XRProtoUIToolKit;

[CustomEditor(typeof(XRProtoUIToolKit.ScreenManager), true)]
public class ScreenManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        ScreenManager script = (ScreenManager)target;


        // script.ElementsOrder = (ElementsOrder)EditorGUILayout.EnumPopup("Elements Order", script.ElementsOrder);

        GUILayout.Space(10);
        if (GUILayout.Button("Show"))
            script.Show(script.ElementsOrder);
        if (GUILayout.Button("Hide"))
            script.Hide(script.ElementsOrder);
    }
}