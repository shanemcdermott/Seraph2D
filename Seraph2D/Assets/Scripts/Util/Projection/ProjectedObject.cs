using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Renderer))]
public class ProjectedObject : MonoBehaviour 
{
	[Tooltip("Use this to offset the object slightly in front or behind the Target object")]
	public float floorOffset = 0;

	[Tooltip("If true, depth is recalculated at runtime")]
	public bool canMove = false;

	void Start()
	{
		CalculateZ ();
	}

	void CalculateZ()
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		Bounds b = renderer.sprite.bounds;
		Vector3 pos = transform.position;
		pos.z = pos.y + b.min.y + floorOffset;

		transform.position = pos;
	}

	void Update()
	{
		if (!Application.isPlaying || canMove) 
		{
			CalculateZ ();
		}

	}

	void OnDrawGizmos()
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		Bounds b = renderer.sprite.bounds;
		Vector3 min = transform.position;
		min.y += b.min.y + floorOffset;
		Vector3 max = min + new Vector3 (2 * b.extents.x, 0, 0);
		Gizmos.DrawLine (min, max);
	}
}