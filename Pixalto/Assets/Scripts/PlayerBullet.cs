using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    //Public variables
	public AudioClip audioClip;
    public float lifetime;
    public float moveSpeed;

    //Private variables
	AudioSource audioSource;

	//Use this for initialization
	void Start()
	{
		audioSource = GetComponent<AudioSource>();

        //Begin the death coroutine
        //This happens because the bullet has a fixed lifetime
		StartCoroutine("Death");
	}
	
	//Update is called once per frame
	void Update()
	{
        //Change position of bullet
		Vector3 temp = GetComponent<Transform>().position;
		temp.x += moveSpeed;
		GetComponent<Transform>().position = temp;
	}

    /// <summary>
    /// Event called when a collider collides with this one
    /// </summary>
    /// <param name="collision">The collision object</param>
	void OnCollisionEnter2D(Collision2D collision)
	{
        //Play the bullet impact sound effect
		audioSource.PlayOneShot(audioClip);

        //If colliding with a platform, destroy this bullet
		if(collision.gameObject.tag == "Platform")
		{
			Destroy(gameObject);
		}

        //If colliding with an enemy and the enemy isn't befriended, destroy the enemy and this bullet
        //Otherwise, just deatroy this bullet
		if(collision.gameObject.tag == "Enemy")
		{
			if(!collision.gameObject.GetComponent<Enemy>().Befriended)
			{
				Destroy(collision.gameObject.gameObject);
			}

			Destroy(gameObject);
		}
	}

    /// <summary>
    /// Destroys this bullet after its lifetime
    /// </summary>
	IEnumerator Death()
	{
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}
}
