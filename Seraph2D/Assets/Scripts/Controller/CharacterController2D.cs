using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    protected AbilityController abilityController;
    protected MovementControls2D movementControls;
    protected Animator animator;

	// Use this for initialization
	void Start ()
    {
        abilityController = GetComponentInChildren<AbilityController>();
        movementControls = GetComponent<MovementControls2D>();
        animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (abilityController.IsAbilityActive) return;

        bool isUsingAbility = abilityController.GetAbilityUse();

        movementControls.SetCasting(isUsingAbility);
        if(!isUsingAbility)
        {
            movementControls.ProcessInput();
        }
	}

    void FixedUpdate()
    {
		movementControls.ApplyMovement ();
        int moveDir = Direction.FromVector2(movementControls.GetMoveDir());
        animator.SetInteger("Direction", moveDir);
    }
}
