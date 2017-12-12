using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Tracks "player's" transform and shoots attached bullet object at frequency of "firerate".
 */
public class EnemyShoot : MonoBehaviour {

    public GameObject bullet;
    public Transform shotSpawn;
    public float fireRate;
    public bool canShoot;
    public float rotSpeed =5f;


    private float nextFire;



    void FixedUpdate ()
    {
        if (Time.time > nextFire && canShoot)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        }

    }
}
