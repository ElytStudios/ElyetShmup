using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Changes lasers position dynamicly according to a raycast that hits anything in the "Shootable" layer below the attatached object.
 */
public class LaserHazard : MonoBehaviour
{
    public GameObject laser;

    Transform laserTr;
    SpriteRenderer laserSr;
    BoxCollider2D laserCl;

    int shootableMask;
    float center;
    float range = 100f;

    private void Start()
    {
        laserTr = transform.GetChild(0);
        laserSr = laser.GetComponent<SpriteRenderer>();
        laserCl = laser.GetComponent<BoxCollider2D>();
        shootableMask = LayerMask.GetMask("Shootable");
    }

    private void FixedUpdate()
    {
        //Math to change the lasers position and size according to hit.
        if (Physics2D.Raycast(transform.position, -transform.up, range, shootableMask)) //Laser doesn't exist if theres nothing to hit.
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, range, shootableMask);
            center = (transform.position.y - hit.point.y) / 2;
            laserSr.size = new Vector2(laserSr.size.x, center * 2);
            laserTr.position = new Vector3(transform.position.x, center + hit.point.y, transform.position.z);

            laserCl.size = new Vector2(laserCl.size.x, laserSr.size.y);
        }
        else
        {
            laserSr.size = new Vector2();
            laserCl.size = new Vector2();
        }
    }
}
