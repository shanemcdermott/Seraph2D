using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cell))]
public class CellEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Cell cell = (Cell)target;
        
        if(GUILayout.Button("Add Cell"))
        {
            GameObject gameO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Cell newCell = gameO.AddComponent<Cell>();
            cell.AddConnection(newCell);
        }
    }

}
