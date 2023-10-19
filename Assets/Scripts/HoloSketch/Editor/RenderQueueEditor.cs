using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HoloSketch;

[CustomEditor(typeof(RenderQueue))]

public class RenderQueueEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RenderQueue script = (RenderQueue)target;

        if (GUILayout.Button("ApplyQueue"))
            script.UpdateQueue();
    }
}
