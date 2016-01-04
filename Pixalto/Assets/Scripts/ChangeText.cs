using UnityEngine;
using System.Collections;

public class ChangeText : MonoBehaviour
{
	// Use this for initialization
	void Start()
    {
	}
	
	// Update is called once per frame
	void Update()
    {
	}

    /// <summary>
    /// Event called when the object this script is attached to collides with another object
    /// </summary>
    /// <param name="collision">The collision object, from which the GameObject collided with can be gotten</param>
	void OnCollisionEnter2D(Collision2D collision)
	{
        //If this object collides with the player
		if(collision.gameObject.tag == "Player")
		{
            //Get a list of all SpriteRenderers attached to this GameObject
			SpriteRenderer[] sprites = transform.parent.GetComponentsInChildren<SpriteRenderer>();

            //Switch from the "stay close" message to the "ouch" message
            //Though this way of switching sprites, with the access through the array, would not necessarily
            //be sustainable as the number of components on this GameObject increases, it is an easy way of
            //doing it that works for a minigame
			sprites[1].enabled = false;
			sprites[2].enabled = true;
		}
	}
}
