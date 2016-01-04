using UnityEngine;
using System.Collections;

public class HorPlatformMovement : MonoBehaviour
{
    //Private variables
	bool dirRight = true;

    //Public variables
    public float distanceToTraverse = 2;
    public float initialPosition;
    public float speed = 2f;
    public int xDirection = 1;	//for moving the platform to left at start by changing this value to -1

	// Use this for initialization
	void Start()
    {
		initialPosition = transform.position.x;
        if(xDirection == -1)
        {
            dirRight = false;
        }
	}
	
	// Update is called once per frame
	void Update()
    {
        if(dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }

		if((transform.position.x - initialPosition) >= distanceToTraverse)
        {
			dirRight = false;
		}
		
		if((transform.position.x - initialPosition) <= -distanceToTraverse)
        {
			dirRight = true;
		}
	}
}
