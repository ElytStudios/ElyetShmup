
using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{

    public Transform[] patrolpoints;
    public float speed = 0.5f;
    public float timestill = 2f;
    public float sight = 3f;

    float waitTimer;
    int currentPoint;
    bool isAgroad;

    // Use this for initialization
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer += Time.deltaTime;
        print(waitTimer);
        if (transform.position.x == patrolpoints[currentPoint].position.x && waitTimer >= timestill)
        {
            print("reached poss" + currentPoint);
            currentPoint++;
            waitTimer = 0;
        }

        if (currentPoint >= patrolpoints.Length)
        {
            currentPoint = 0;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, sight);
        if ((hit.collider != null && hit.collider.tag == "Player"))
        {
            isAgroad = true;
        }

        if (!isAgroad)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(patrolpoints[currentPoint].position.x, transform.position.y), speed);

            if (transform.position.x > patrolpoints[currentPoint].position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (transform.position.x < patrolpoints[currentPoint].position.x)
                transform.localScale = Vector3.one;
        }

        if(isAgroad)
        {
            //Put agro code here
        }

    }


    IEnumerator Patrol()
    {
        while (true)
        {



        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
            Destroy(this.gameObject, 0.1f);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * sight);

    }

}