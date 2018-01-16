using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhyics : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        //rb.AddForce(transform.right * speed);
        rb.velocity = new Vector2(speed, 0);
	}
}
