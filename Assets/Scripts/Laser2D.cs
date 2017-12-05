using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Turns laser on and of according to  up and down timel
 */
public class Laser2D : MonoBehaviour {

    public float downTime; //delay of laser turning on
    public float UpTime; // how long laser is on
    public bool isLaserOn = true; 

    LineRenderer laserLine;

    float timer;

    SpriteRenderer laserSr;
    BoxCollider2D laserCl;

    int shootableMask;
    float center;

    // Use this for initialization
    void Start ()
    {
        laserSr = GetComponent<SpriteRenderer>();
        laserCl = GetComponent<BoxCollider2D>();
    }
	
    private void Update()
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
