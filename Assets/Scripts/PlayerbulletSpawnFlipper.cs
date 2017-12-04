using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerbulletSpawnFlipper : MonoBehaviour {

    public PlayerMovement pm;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) && !pm.isFliped)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;

        }

        if (Input.GetKey(KeyCode.D) && pm.isFliped)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}
