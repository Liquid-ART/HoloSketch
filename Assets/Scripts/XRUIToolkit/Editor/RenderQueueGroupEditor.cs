using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XRProtoUIToolKit;

[CustomEditor(typeof(RenderQueueGroup))]

public class RenderQueueGroupEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RenderQueueGroup script = (RenderQueueGroup)target;

        if (GUILayout.Button("Apply Queue To Childrens"))
            script.UpdateGroup();
    }
}
