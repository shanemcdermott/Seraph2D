﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_EDITOR)
using UnityEditor;

[CustomEditor(typeof(TileAStar))]
public class AStarEditor : Editor {

    public  void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TileAStar world = (TileAStar)target;

        if(GUILayout.Button("Clear"))
        {
            world.Clear();
        }
        if(GUILayout.Button("Find Path"))
        {
            world.FindPath();
        }
        if(GUILayout.Button("Smooth Path"))
        {
            world.SmoothPath();
        }

        /*
        if (GUILayout.Button("Subdivide"))
        {
            world.Subdivide();
        }
        if(GUILayout.Button("Clear Tiles"))
        {
            world.DestroyTiles();
        }
        */
    }
}
#endif