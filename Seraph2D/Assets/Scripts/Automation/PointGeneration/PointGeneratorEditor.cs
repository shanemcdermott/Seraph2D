using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_EDITOR)
using UnityEditor;

[CustomEditor(typeof(PointGenerator))]
public class PointGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();
        PointGenerator clutter = (PointGenerator)target;
        if (GUILayout.Button("Initialize"))
        {
            clutter.Init();
        }
        if (GUILayout.Button("Next Point"))
        {
            clutter.NextPoint();
        }
    }
}
#endif