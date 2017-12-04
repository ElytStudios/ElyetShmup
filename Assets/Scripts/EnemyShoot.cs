using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Tracks "players" transform and shoots attached bullet object at frequency of "firerate".
 */
public class EnemyShoot : MonoBehaviour {

    public GameObject bullet;
    public Transform shotSpawn;
    public float fireRate;
    public bool canShoot;
    public float rotSpeed =5f;

    private Transform player;
    private float nextFire;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate ()
    {
        Vector2 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);

        if (Time.time > nextFire && canShoot)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        }

    }
}
