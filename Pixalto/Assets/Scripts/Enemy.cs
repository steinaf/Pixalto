using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
	//Public variables
	public AudioClip[] audioClips = new AudioClip[2];
	public int damage;
	public int initialNumPixels;
	public bool isTutorialEnemy;
	public float moveVelocity;
	public float oneDirectionWalkTime;
	public GameObject[] pixelTypes = new GameObject[3];
	public float pixelSideLength;

	//Hostile public variables
	public float chargeRangeX;
	public float chargeRangeY;
	public float chargeVelocity;
	public float oneDirectionChargeTime;
	public float recognitionWaitTime;

	//Non-hostile public variables
	public float befriendRangeX;
	public float befriendRangeY;
	public float befriendTime;
	public float befriendedMoveVelocity;
	public float oneDirectionBefriendedWalkTime;

	//Private variables
	AudioSource audioSource;
	bool isHostile;
	Transform myTransform;
	List<GameObject> pixels;
    int pixelType;
	GameObject player;
	float timeSinceTurn;

	//Hostile enemy private variables
	bool charging;
	bool sawPlayer;

	//Non-hostile enemy private variables
	bool befriended;
	float befriendStartTime;
	bool beingBefriended;
	List<Color> origPixelColors;

	//Properties
	public bool Befriended
	{
		get{return befriended;}
	}

	public int Damage
	{
		get{return damage;}
	}

	public bool IsHostile
	{
		set{isHostile = value;}
	}

    public int PixelType
    {
        get { return pixelType; }
    }

	// Use this for initialization
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		befriended = false;
		befriendStartTime = 0f;
		beingBefriended = false;
		charging = false;
		myTransform = GetComponent<Transform>();
		origPixelColors = new List<Color>();
		pixels = new List<GameObject>();
		player = GameObject.Find("Player");
		sawPlayer = false;
		timeSinceTurn = 0f;

        //Build up the enemy's body out of pixels
		BuildSelf();

        //Randomize whether this enemy is hostile
		RandomizeHostility();
	}
	
	// Update is called once per frame
	void Update()
	{
        //If this enemy is hostile
		if(isHostile)
		{
            //If this enemy isn't charging and hasn't yet seen the player
			if(!charging && !sawPlayer)
			{
                //Move at normal speed and check for the player
				Move();
				CheckForPlayer();
			}
            //If this enemy is charging
			else if(charging)
			{
                //Move at charge speed
				MoveCharge();
			}
		}
        //If this enemy is non-hostile
		else
		{
            //If this enemy hasn't been befriended
			if(!befriended)
			{
                //Move at normal speed and check for the player
				Move();
				CheckForPlayer();
			}
            //If this enemy has been befriended
			else
			{
                //Move at befriended speed
				MoveBefriended();
			}
		}

        //Add this frame's delta time
        //This will be used to see if the enemy should change direction
		timeSinceTurn += Time.deltaTime;

        //If this enemy isn't charging
		if(!charging)
		{
            //If this enemy isn't befriended
			if(!befriended)
			{
                //Check for normal one direction walk time
				if(timeSinceTurn > oneDirectionWalkTime)
				{
                    //Change direction and reset counter
					befriendedMoveVelocity *= -1f;
					moveVelocity *= -1;
					timeSinceTurn = 0f;
				}
			}
            //If this enemy is befriended
			else
			{
                //Check for befriended one direction walk time
				if(timeSinceTurn > oneDirectionBefriendedWalkTime)
				{
                    //Change direction and reset counter
					befriendedMoveVelocity *= -1f;
					timeSinceTurn = 0f;
				}
			}
		}
        //If this enemy is charging
		else
		{
            //Check for one direction charge time
			if(timeSinceTurn > oneDirectionChargeTime)
			{
                //Stop charging
				charging = false;

                //Change direction and reset timer
				if(chargeVelocity < 0)
				{
					if(moveVelocity < 0)
					{
						moveVelocity *= -1f;
					}
				}
				timeSinceTurn = 0f;
			}
		}
	}

    /// <summary>
    /// Builds this enemy out of pixels
    /// </summary>
	void BuildSelf()
	{
        //Choose a random pixel color
		pixelType = Random.Range(0, 3);

        //Add the initial number of pixels to this enemy
		for(int i = 0; i < initialNumPixels; i++)
		{
			AddPixel(pixelType);
		}
	}

    /// <summary>
    /// Builds this enemy out of a specific color of pixels
    /// </summary>
    /// <param name="pixelType">The pixel color to build from</param>
	void BuildSelf(int pixelType)
	{
        //Add the initial number of pixels to this enemy
		for(int i = 0; i < initialNumPixels; i++)
		{
			AddPixel(pixelType);
		}
	}

    /// <summary>
    /// Randomizes this enemy's hostility property
    /// This determines whether this enemy is befriendable or will charge at the player
    /// </summary>
	void RandomizeHostility()
	{
        //If this enemy isn't in the tutorial
        //Randomize the hostil property
		if(!isTutorialEnemy)
		{
			if(Random.Range(0, 2) == 0)
			{
				isHostile = false;
			}
			else
			{
				isHostile = true;
			}
		}
        //Special conditions for the tutorial so that one enemy can be
        //guaranteed non-hostile and the other can be guaranteed hostile
		else
		{
			if(myTransform.position.x < 37)
			{
				isHostile = false;
			}
			else
			{
				isHostile = true;
			}
		}
	}
	
	/// <summary>
	/// Adds a pixel to the enemy's body
	/// </summary>
	void AddPixel(int pixelType)
	{
        //Instantiate the pixel game object that has been randomly or purposefully selected
		GameObject p = Instantiate(pixelTypes[pixelType], this.transform.position, this.transform.rotation) as GameObject;
		
        //This pixel will be a child of the enemy's GameObject
        p.transform.parent = myTransform;
		
		//Calculate the row and column that the added pixel will be in
		//Zero indexed at bottom left
		int column = pixels.Count % 3;
		int row = (int)Mathf.Floor(pixels.Count / 3);
		
		//Adjust the color of the pixel based on its position on the player
		//Closer to top right means darker
		Color c = p.GetComponent<SpriteRenderer>().color;
		c.r = c.g = c.b = 1 - ((column + row) * .1f);
		p.GetComponent<SpriteRenderer>().color = c;

        //Save the original pixel color in case befriending changes the enemy's color
		origPixelColors.Add(c);

		//Adjust the position of the pixel based on the row and column calculated
		Vector3 temp = p.transform.position;
		temp.x += column * pixelSideLength;
		temp.y += row * pixelSideLength;
		p.transform.position = temp;
		
        //Add the pixel to the enemy's list of pixels
		pixels.Add(p);
	}

    /// <summary>
    /// Move this enemy at normal speed
    /// </summary>
	void Move()
	{
        //Save the position in a temp vector
		Vector3 temp = myTransform.position;

        //Adjust by move velocity
		temp.x += moveVelocity;

        //Change the enemy's position
		myTransform.position = temp;
	}

    /// <summary>
    /// Move this enemy at befriended speed
    /// </summary>
	void MoveBefriended()
	{
		Vector3 temp = myTransform.position;
		temp.x += befriendedMoveVelocity;
		myTransform.position = temp;
	}

    /// <summary>
    /// Move this enemy at charge speed
    /// </summary>
	void MoveCharge()
	{
		Vector3 temp = myTransform.position;
		temp.x += chargeVelocity;
		myTransform.position = temp;
	}

    /// <summary>
    /// Check whether the player is within range for befriending (non-hostile) or charging (hostile)
    /// </summary>
	void CheckForPlayer()
	{
        //Get the player's position and diff it against this enemy's position
		Vector3 playerPos = player.transform.position;
		float diffX = Mathf.Abs(playerPos.x - myTransform.position.x);
		float diffY = Mathf.Abs(playerPos.y - myTransform.position.y);

        //If this enemy is hostile and hasn't seen the player
		if(isHostile && !sawPlayer)
		{
            //Check the diff against the charge range
			if(diffX <= chargeRangeX && diffY <= chargeRangeY)
			{
                //Adjust charge direction based on diff
				if(playerPos.x - myTransform.position.x < 0)
				{
					if(chargeVelocity > 0)
					{
						chargeVelocity *= -1;
					}
				}
				else
				{
					if(chargeVelocity < 0)
					{
						chargeVelocity *= -1;
					}
				}

                //Begin the charge
				StartCoroutine("Charge");
			}
		}
        //If this enemy isn't hostile
		else
		{
            //Check the diff against the befriend range
			if(diffX <= befriendRangeX && diffY <= befriendRangeY)
			{
                //If in process of being befriended, befriend further
				if(beingBefriended)
				{
					StartCoroutine("Befriend");
				}
                //If not in process of being befriended, start befriending
				else
				{
					befriendStartTime = Time.time;
					beingBefriended = true;
				}
			}
            //If not in befriended range
			else
			{
                //If in process of being befriended, stop befriending
				if(beingBefriended)
				{
					beingBefriended = false;

                    //Switch back to original pixel colors
					for(int i = 0; i < pixels.Count; i++)
					{
						pixels[i].GetComponent<SpriteRenderer>().color = origPixelColors[i];
					}
				}
			}
		}
	}

    /// <summary>
    /// Have this enemy charge
    /// </summary>
	IEnumerator Charge()
	{
        //Show the exclamation point over this enemy's head
		GetComponentInChildren<SpriteRenderer>().enabled = true;
		sawPlayer = true;

        //Play the associated sound
		audioSource.PlayOneShot(audioClips[0]);

        //Wait for the recognition time
		yield return new WaitForSeconds(recognitionWaitTime);

        //Hide the exclamation point over this enemy's head
		GetComponentInChildren<SpriteRenderer>().enabled = false;

		sawPlayer = false;
		charging = true;
	}

    /// <summary>
    /// Befriend this enemy
    /// </summary>
	IEnumerator Befriend()
	{
        //If this enemy has been being befriended for enough time
		if(Time.time - befriendStartTime > befriendTime)
		{
            befriended = true;
            audioSource.volume = .15f;

            //Play the befriended sound effect
			audioSource.PlayOneShot(audioClips[1]);
            yield return new WaitForSeconds(2f);
            audioSource.volume = 1f;
		}
        //If the befriend time hasn't been reached
		else
		{
            yield return new WaitForSeconds(0f);
            
            //Make all pixels bluer
			for(int i = 0; i < pixels.Count; i++)
			{
				Color c = pixels[i].GetComponent<SpriteRenderer>().color;
				c.r -= .005f;
				c.g -= .005f;
				c.b += .01f;
				pixels[i].GetComponent<SpriteRenderer>().color = c;
			}
		}
	}
}
