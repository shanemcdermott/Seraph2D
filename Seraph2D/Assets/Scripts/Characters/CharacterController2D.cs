using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    protected MovementControls2D movementControls;
    protected Animator animator;

	// Use this for initialization
	void Start ()
    {
        movementControls = GetComponent<MovementControls2D>();
        animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		movementControls.ProcessInput ();
	}

    void FixedUpdate()
    {
		movementControls.ApplyMovement ();
        int moveDir = Direction.FromVector2(movementControls.GetMoveDir());
        animator.SetInteger("Direction", moveDir);
    }
}
