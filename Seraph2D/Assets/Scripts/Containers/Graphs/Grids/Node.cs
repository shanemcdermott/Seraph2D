using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Node : MonoBehaviour, IHasConnections<Node>
{
    protected List<IConnection<Node>> edges = new List<IConnection<Node>>();

    /// <summary>
    /// Adds CellEdge to edges as well as to @connection's edges.
    /// </summary>
    /// <param name="connection">
    /// The 'to' Cell to add a connection to.
    /// </param>

    public void AddConnection(Node connection)
    {
        if(IsNullOrThis(connection))
        {
            return;
        }
        if(IsConnectedTo(connection))
        {
            Debug.Log("Already connected to " + connection.ToString());
        }
        else
        {
            NodeEdge ce = new NodeEdge(this, connection);
            edges.Add(ce);
            if(!connection.IsConnectedTo(this))
            {
                connection.edges.Add(ce);
            }
        }


    }

    public void RemoveConnection(Node connection)
    {
        int i = IndexOf(connection);
        if(i >= 0)
        {
            edges.RemoveAt(i);
            connection.RemoveConnection(this);
        }
    }

    public bool IsNullOrThis(Node c)
    {
        return c == null || c.Equals(this);
    }

    public int IndexOf(Node other)
    {
        if(IsNullOrThis(other))
        {
            return -1;
        }

        for(int i = 0; i < edges.Count; i++)
        {
            if(edges[i].HasNode(other))
            {
                return i;
            }
        }

        return -1;
    }

    public bool IsConnectedTo(Node other)
    {
        return IndexOf(other) > -1;
    }

    public int NumConnections()
    {
        return edges.Count;
    }

    public void GetConnections(out List<IConnection<Node>> connections)
    {
        connections = new List<IConnection<Node>>();
        foreach(NodeEdge e in edges)
        {
            connections.Add(e);
        }
    }

    public void OnDrawGizmos()
    {
        DrawConnections();
    }

    public void DrawConnections()
    {
        foreach (NodeEdge e in edges)
        {
            Node c = e.GetToNode();
            if (c != null)
            {
                Gizmos.DrawLine(transform.position, c.transform.position);
            }
        }
    }

}
