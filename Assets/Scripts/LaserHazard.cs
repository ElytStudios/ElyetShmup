using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Changes lasers position dynamicly according to a 
 * raycast that hits anything in the "Shootable" layer
 * below the attatached object.
 * 
 * NOTE: If scrip has inbuilt use of "Turn of" and "Turn on" . 
 * Set downtime to 0 to keep laser on/off.
 */
public class LaserHazard : MonoBehaviour
{
    public float maxRange;
    public float downTime; //delay of laser turning on
    public float UpTime; // how long laser is on
    public bool isLaserOn = true;

    Animator anim;
    Transform laserTr;
    SpriteRenderer laserSr;
    BoxCollider2D laserCl;

    float timer;
    int shootableMask;

    private void Start()
    {
        anim = GetComponent<Animator>();
        laserSr = GetComponent<SpriteRenderer>();
        laserCl = GetComponent<BoxCollider2D>();
        shootableMask = LayerMask.GetMask("SolidPlatform");
    }

    private void FixedUpdate()
    {
        if (downTime != 0)
        {
            timer += Time.deltaTime;

            if (timer >= downTime && isLaserOn == false)
            {
                laserOn();
            }

            if (timer >= UpTime && isLaserOn == true)
            {
                laserOff();
            }
        }
        //Math to change the lasers position and size according to hit.
        if (Physics2D.Raycast(transform.position, -transform.up, maxRange, shootableMask)) //Laser doesn't exist if theres nothing to hit.
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, maxRange, shootableMask);
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

    private void OnTriggerEnter2D()
    {
        //TODO: Kill player
    }

    public void laserOff()
    {
        laserSr.color = Color.clear;
        timer = 0f;
        isLaserOn = false;
        laserCl.enabled = false;
    }

    public void laserOn()
    {
        laserSr.color = Color.white;
        timer = 0f;
        isLaserOn = true;
        laserCl.enabled = true;
    }
}
