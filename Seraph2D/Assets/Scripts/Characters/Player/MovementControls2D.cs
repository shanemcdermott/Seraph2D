using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls2D : MonoBehaviour 
{
	public float speed = 1;

	private Vector3 moveDir;

	void Start()
	{
		moveDir = new Vector3 ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		moveDir.x = Input.GetAxis ("Horizontal") * speed * Time.fixedDeltaTime;
		moveDir.y = Input.GetAxis ("Vertical") * speed * Time.fixedDeltaTime;
		transform.position += moveDir;
	}


}
