using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyOver : MonoBehaviour
{

    public float speed = 1f;
    public float flipRange = 1f;

    private bool flipped;
    private Transform player;
    private bool inRange = false;

    float timer;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (((player.transform.position.x - transform.position.x) < flipRange && (player.transform.position.x - transform.position.x) > -flipRange))
        {
            inRange = true;
        }
        else if (player.transform.position.x > transform.position.x && !inRange)
        {
            transform.localScale = new Vector3(1, 1, 1);
            flipped = false;
        }
        else if (player.transform.position.x < transform.position.x && !inRange)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            flipped = true;
        }


        if ((player.transform.position.x - transform.position.x) < -flipRange || (player.transform.position.x - transform.position.x) > flipRange)
        {
            inRange = false;
        }


        if (!flipped)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        else if (flipped)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }
}
