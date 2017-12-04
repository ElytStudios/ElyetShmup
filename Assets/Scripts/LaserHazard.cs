using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Changes lasers position dynamicly according to a raycast that hits anything in the "Shootable" layer below the attatached object.
 */
public class LaserHazard : MonoBehaviour
{
    public float maxRange;

    Transform laserTr;
    SpriteRenderer laserSr;
    BoxCollider2D laserCl;

    int shootableMask;

    float range = 50f;

    private void Start()
    {
        laserSr = GetComponent<SpriteRenderer>();
        laserCl = GetComponent<BoxCollider2D>();
        shootableMask = LayerMask.GetMask("SolidPlatform");
    }

    private void FixedUpdate()
    {
        //Math to change the lasers position and size according to hit.
        if (Physics2D.Raycast(transform.position, -transform.up, range, shootableMask)) //Laser doesn't exist if theres nothing to hit.
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, range, shootableMask);
            laserSr.size = new Vector2(laserSr.size.x, hit.distance);
            laserCl.size = new Vector2(laserCl.size.x, laserSr.size.y);
            print("Is Htiing");
        }
        else
        {
            laserSr.size = new Vector2(laserSr.size.x, maxRange);
            laserCl.size = new Vector2(laserCl.size.x, laserSr.size.y);
            print("Not Htiing");
        }
    }
}
