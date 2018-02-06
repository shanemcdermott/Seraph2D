using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_EDITOR)
using UnityEditor;

[CustomEditor(typeof(ClutterPlacement))]
public class ClutterPlacementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();
        ClutterPlacement clutter = (ClutterPlacement)target;
        if(GUILayout.Button("Place Clutter"))
        {
            clutter.placeClutter();
        }
        if(GUILayout.Button("Clear Clutter"))
        {
            clutter.clearClutter();
        }
    }
}
#endif