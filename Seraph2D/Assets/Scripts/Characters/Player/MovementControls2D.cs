using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls2D : MonoBehaviour 
{
	public float speed = 1;

    private Vector3 moveSpeed;
	private Vector2 moveDir;
    private bool isJumping;

	void Start()
	{
        moveSpeed = new Vector3();
		moveDir = new Vector2 ();
        isJumping = false;
	}

	public void ProcessInput () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.y = Input.GetAxis("Vertical");

        moveSpeed.x = moveDir.x * speed * Time.fixedDeltaTime;
		moveSpeed.y = moveDir.y * speed * Time.fixedDeltaTime;
        transform.position += moveSpeed;
	}

    public void SetJumping(bool jumping)
    {
        isJumping = jumping;
    }

    public Vector3 GetMoveSpeed()
    {
        return moveSpeed;
    }

    public Vector2 GetMoveDir()
    {
        return moveDir;
    }

}
