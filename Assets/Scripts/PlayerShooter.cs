using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls pl;ayer shooting.
 * Spawns "bullet" at "shotSpawn"
 */

public class PlayerShooter : MonoBehaviour
{

    public float timeBetweenBullets = 0.15f;
    public GameObject bullet;
    public Transform shotSpawn;
    public PlayerMovement pM;
    public float speed;
    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            timer = 0f;

            if (pM.isFliped)
            {
                GameObject bullet2d = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                bullet2d.transform.Rotate(new Vector3(0, 0, 200));
            }
            else
            {
                GameObject bullet2d = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                bullet2d.transform.Rotate(new Vector3());
            }
        }
    }
    
}