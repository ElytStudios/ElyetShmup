using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerOnX : MonoBehaviour
{

    private Transform player;
    
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
	}
}
