using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls pl;ayer shooting.
 * Spawns "bullet" at "shotSpawn"
 */

public class test : MonoBehaviour
{

	public float timeBetweenBullets = 0.15f;
	public GameObject bullet;
	public Transform shotSpawn;
	public EnemyPatrol pM;
	public float speed;
	float timer;
	public float sight=3f;

	// Update is called once per frame
	void Update()
	{



		timer += Time.deltaTime;

		RaycastHit2D hit= Physics2D.Raycast (transform.position, transform.localScale.x * Vector2.right, sight);
		if ((hit.collider != null && hit.collider.tag == "Player"))
		{
			timer = 0f;

				GameObject bullet2d = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
				bullet2d.transform.Rotate(new Vector3(0, 0, 180));


		           
					

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

