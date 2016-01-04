using UnityEngine;
using System.Collections;

public class VerPlatformMovement : MonoBehaviour
{
    //Public variables
	public float initialPosition;
	public int yDirection = 1;	//for moving the platform to down at start by changing this value to -1
	public float distanceToTraverse = 2;
	public float speed = 2f;

    //Private variables
    bool dirUp = true;

	// Use this for initialization
	void Start()
    {
		initialPosition = transform.position.y;
        if (yDirection == -1)
        {
            dirUp = false;
        }
	}
	
	// Update is called once per frame
	void Update()
    {
        if(dirUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }
		
		if((transform.position.y - initialPosition) >= distanceToTraverse)
        {
			dirUp = false;
		}
		
		if((transform.position.y - initialPosition) <= -distanceToTraverse)
        {
			dirUp = true;
		}
	}
}

