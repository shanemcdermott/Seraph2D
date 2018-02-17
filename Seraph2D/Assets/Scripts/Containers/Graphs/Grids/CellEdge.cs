using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellEdge : BaseConnection<Cell>
{
    public CellEdge(Cell from, Cell to) : base(from, to)
    {
    }
}
