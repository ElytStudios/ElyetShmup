using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Changes "allowed to jump" bool in Player movement.
 * Done by checking if attached object is colliding in ground.
 */

public class GroundCheck : MonoBehaviour {

    PlayerMovement pm;

	// Use this for initialization
	void Start ()
    {
        pm = GetComponentInParent<PlayerMovement>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player can jump
        pm.canJump = true;

        //can fall
        if(collision.CompareTag("ThinPlatform"))
        {
            pm.canFall = true;
        }
        else
        {
            pm.canFall = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pm.canJump = false;
    }
}
