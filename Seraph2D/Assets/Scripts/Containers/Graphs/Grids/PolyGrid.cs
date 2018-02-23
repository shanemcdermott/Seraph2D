using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyGrid : MonoBehaviour
{
    [SerializeField]
    protected List<Node> faces;

    [SerializeField]
	protected List<Node> vertices = new List<Node>();


	public void AddVertex(Node newVertex)
	{
		vertices.Add (newVertex);
	}

	public void Triangulate()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
