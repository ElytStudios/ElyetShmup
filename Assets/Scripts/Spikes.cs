using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sends player to attached spawn location when they hit the collider of the attatched object.
 */
public class Spikes : MonoBehaviour {

    public GameObject spawnLoc;

    PlayerMovement pm;

    private void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D()
    {
        pm.GetComponent<Rigidbody2D>().position = spawnLoc.transform.position;
        pm.deaths++;
    }
}
