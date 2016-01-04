using UnityEngine;
using System.Collections;

public class EnemyPixel : MonoBehaviour
{
    //Private variables
	GameObject parentEnemy;
	GameObject player;

	//Use this for initialization
	void Start()
	{
		parentEnemy = transform.parent.gameObject;
		player = GameObject.Find("Player");
	}
	
	//Update is called once per frame
	void Update()
	{
	}

    /// <summary>
    /// Event called when this GameObject collides with another one
    /// </summary>
    /// <param name="collision">The collision object</param>
	void OnCollisionEnter2D(Collision2D collision)
	{
        //If the colliding object is the player
		if(collision.gameObject.tag == "Player")
		{
            //Unless the enemy is befriended or the player is invulnerable, hit the player with this enemy's damage
			if(!parentEnemy.GetComponent<Enemy>().Befriended && !player.GetComponent<Player>().Invulnerable)
			{
				StartCoroutine(player.GetComponent<Player>().Hit(parentEnemy.GetComponent<Enemy>().Damage));
			}
		}
	}
}
