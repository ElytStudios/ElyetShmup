
using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public Transform[] patrolpoints;
	int currentPoint;
	public float speed=0.5f;
	public float timestill=2f;
	public float sight=3f;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Patrol");
		Physics2D.queriesStartInColliders = false;
	}

	// Update is called once per frame
	void Update () {
	}


	IEnumerator Patrol()
	{
		while (true) {

			if(transform.position.x== patrolpoints[currentPoint].position.x )
			{
				currentPoint++;

				yield return new WaitForSeconds(timestill);

			}


			if(currentPoint >=patrolpoints.Length)
			{
				currentPoint=0;
			}

			transform.position=Vector2.MoveTowards(transform.position,new Vector2(patrolpoints[currentPoint].position.x,transform.position.y),speed);

			if(transform.position.x> patrolpoints[currentPoint].position.x)
				transform.localScale=new Vector3(-1,1,1);
			else if (transform.position.x< patrolpoints[currentPoint].position.x)
				transform.localScale= Vector3.one;


			yield return null;

			RaycastHit2D hit= Physics2D.Raycast (transform.position, transform.localScale.x * Vector2.right, sight);
			if ((hit.collider != null && hit.collider.tag == "Player")) {
				yield return new WaitForSeconds (100f);



			} 
				
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Projectile")
			Destroy (this.gameObject, 0.1f);
	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawLine (transform.position, transform.position + transform.localScale.x * Vector3.right * sight);

	}

}