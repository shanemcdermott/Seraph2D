using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEdge : MonoBehaviour, IConnection<Vector3>
{
    public float weight;
    public Vector3 from;
    public Vector3 to;

    public float GetCost()
    {
        return weight;
    }

    public Vector3 GetFromNode()
    {
        return from;
    }

    public Vector3 GetToNode()
    {
        return to;
    }
}
