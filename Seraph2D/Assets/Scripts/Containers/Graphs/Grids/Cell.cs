using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour, IHasConnections<Cell>
{
 

    protected List<CellEdge> edges = new List<CellEdge>();

    /// <summary>
    /// Adds CellEdge to edges as well as to @connection's edges.
    /// </summary>
    /// <param name="connection">
    /// The 'to' Cell to add a connection to.
    /// </param>

    public void AddConnection(Cell connection)
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
            CellEdge ce = new CellEdge(this, connection);
            edges.Add(ce);
            if(!connection.IsConnectedTo(this))
            {
                connection.edges.Add(ce);
            }
        }


    }

    public bool IsNullOrThis(Cell c)
    {
        return c == null || c.Equals(this);
    }

    public bool IsConnectedTo(Cell other)
    {
        if (IsNullOrThis(other))
        {
            return false;
        }

        foreach(CellEdge e in edges)
        {
            if(e.HasNode(other))
            {
                return true;
            }
        }

        return false;
    }

    public void GetConnections(out List<IConnection<Cell>> connections)
    {
        connections = new List<IConnection<Cell>>();
        foreach(CellEdge e in edges)
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
        foreach (CellEdge e in edges)
        {
            Cell c = e.GetToNode();
            if (c != null)
            {
                Gizmos.DrawLine(transform.position, c.transform.position);
            }
        }
    }

}
