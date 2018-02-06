using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ChunkBounds : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		BoxCollider2D box = GetComponent<BoxCollider2D> ();
		box.size = WorldGrid.chunkSize;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<MovementControls2D> ()) 
		{
			WorldGrid._inst.UpdateChunks (this);
		}
	}
}
