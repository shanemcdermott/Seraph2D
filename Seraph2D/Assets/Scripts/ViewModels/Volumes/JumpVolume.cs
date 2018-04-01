using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementControls2D movement = collision.gameObject.GetComponent<MovementControls2D>();
        if(movement)
        {
            movement.SetJumping(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MovementControls2D movement = collision.gameObject.GetComponent<MovementControls2D>();
        if (movement)
        {
            movement.SetJumping(false);
        }
    }
}
