using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState
{
	Idle,
	Walking,
	Running,
	Jumping
}

public class MovementControls2D : MonoBehaviour 
{
	public float walkSpeed = 1;
	public float runSpeed = 2;
	public float jumpSpeed = 1;

    private Vector3 moveSpeed;
	private Vector2 moveDir;
	private MovementState moveState;

	void Start()
	{
        moveSpeed = new Vector3();
		moveDir = new Vector2 ();
		moveState = MovementState.Idle;
	}

	public virtual void ProcessInput () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		SetRunning (Input.GetButtonDown ("Run"));
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.y = Input.GetAxis("Vertical");

	}

	public void ApplyMovement()
	{
		ScaleMoveSpeed ();
		transform.position += moveSpeed;
	}

	private void ScaleMoveSpeed()
	{
		moveDir.Normalize ();
		float speed = 0;
		switch (moveState) 
		{
		case MovementState.Walking:
			speed = walkSpeed;
			break;
		case MovementState.Running:
			speed = runSpeed;
			break;
		case MovementState.Jumping:
			speed = jumpSpeed;
			break;
		}
		moveSpeed.x = moveDir.x * speed * Time.fixedDeltaTime;
		moveSpeed.y = moveDir.y * speed * Time.fixedDeltaTime;
	}

	public bool CanRun()
	{
		return !IsJumping ();
	}

	public void SetRunning(bool running)
	{
		if (running) 
		{
			if (CanRun ()) 
			{
				SetMovementState (MovementState.Running);	
			}
		} 
		else if (IsIdle ()) 
		{
			SetMovementState (MovementState.Idle);
		} 
		else 
		{
			SetMovementState (MovementState.Walking);
		}

	}

	public bool IsIdle()
	{
		return GetMoveSpeed ().Equals (Vector2.zero);
	}

	public bool IsJumping()
	{
		return moveState == MovementState.Jumping;
	}

    public void SetJumping(bool jumping)
    {
		if (jumping) {
			SetMovementState (MovementState.Jumping);
		} else if (IsIdle()) {
			SetMovementState (MovementState.Idle);
		} else {
			SetMovementState (MovementState.Walking);
		}

    }

    public Vector3 GetMoveSpeed()
    {
        return moveSpeed;
    }

    public Vector2 GetMoveDir()
    {
        return moveDir;
    }

	protected virtual void SetMovementState(MovementState state)
	{
		this.moveState = state;
	}
}
