using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Moves attached object forward at "speed".
 * Destroys itself on contact with anything.
 */
public class Bullet : MonoBehaviour
{
    public float speed = 1f;

    private void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
