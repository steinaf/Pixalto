using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
    //Private variables
    BoxCollider2D myCollider2d;
    Transform mytransform;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        mytransform = GetComponent<Transform> ();
        myCollider2d = GetComponent <BoxCollider2D> ();
        player = GameObject.Find("Player");    
	}
	
	// Update is called once per frame
	void Update()
    {
        //Resize the GroundCheck based on the number of pixels in the player
        int nPixels = player.GetComponent<Player>().nPixels;
        if(nPixels == 0)
        {
            myCollider2d.size = new Vector2(0f, 0f);
        }
        else if (nPixels == 1)
        {
            mytransform.position = player.transform.position + new Vector3(0f, -0.8f, 0);
            myCollider2d.size = new Vector2(1.5f, 1f);
        }
        else if(nPixels == 2)
        {
            mytransform.position = player.transform.position + new Vector3(0.5f, -0.8f, 0);
            myCollider2d.size = new Vector2(3.5f, 1f);
        }
        else
        {
            mytransform.position = player.transform.position + new Vector3(1, -0.8f, 0);
            myCollider2d.size = new Vector2(5.5f, 1f);
        }
	
	}

    /// <summary>
    /// Event called when this GameObject is triggered by its collider entering another one
    /// </summary>
    /// <param name="other">The collider colliding with this one</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //If the other's tag is LevelNext, the player can jump
        if(other.tag != "LevelNext")
        {
            player.GetComponent<Player>().CanJump = true;
        }
    }

    /// <summary>
    /// Event called when this GameObject is triggered by its collider staying in another one
    /// </summary>
    /// <param name="other">The collider colliding with this one</param>
    void OnTriggerStay2D(Collider2D other)
    {
        //Toggle jump based on whether the player can move
        if(other.tag != "LevelNext" && player.GetComponent<Player>().CanMove)
        {
            player.GetComponent<Player>().CanJump = true;
        }
        else
        {
            player.GetComponent<Player>().CanJump = false;
        }
    }

    /// <summary>
    /// Event called when this GameObject is triggered by its collider exiting another one
    /// </summary>
    /// <param name="other">The collider colliding with this one</param>
    void OnTriggerExit2D(Collider2D other)
    {
        //Don't let the player jump while it's in the air
        player.GetComponent<Player>().CanJump = false;
    }
}
