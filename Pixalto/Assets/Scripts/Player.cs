using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	//Public variables can be set in the inspector
	public AudioClip[] audioClips = new AudioClip[2];
	public GameObject bullet;
    public Sprite[] enemyPixelSprites = new Sprite[3];
	public int initialNumPixels;
	public float invulnerabilityTimeAfterCollision;
	public Vector2 jumpForce;
    public Vector2 bounceForce;
	public float moveVelocity;
	public GameObject pixel;
	public float pixelSideLength;

    //Private variables must be set in code
    //Variables which aren't specified as public are private by default
    AudioSource audioSource;
    bool canJump;
    bool canMove;
    bool canShoot;
	bool invulnerable;
	Rigidbody2D myRigidbody;
	Transform myTransform;
	List<GameObject> pixels;

	//Properties
    public bool CanJump
    {
        get { return canJump; }
        set { canJump = value; }
    }

    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }
    
    public bool CanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }

    public bool Invulnerable
	{
		get{return invulnerable;}
	}

    public int nPixels
    {
        get { return pixels.Count; }
    }

	// Use this for initialization
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		canJump = false;
		canMove = true;
        canShoot = true;
		invulnerable = false;
		myRigidbody = GetComponent<Rigidbody2D>();
		myTransform = GetComponent<Transform>();
		pixels = new List<GameObject>();

        //Build the player out of pixels
		BuildSelf();
	}
	
	// Update is called once per frame
	void Update()
	{
        //Handle keyboard input
		HandleInput();
	}

    /// <summary>
    /// Event called when a collider collides with this one
    /// </summary>
    /// <param name="collision">The collision object</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the colliding object is a platform, don't move the player with a platform
        if(collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }

        //If the colliding object is a moving platform, move the player with the platform
        if(collision.gameObject.tag == "HorMovingPlatform")
        {
            if(transform.position.y > collision.gameObject.transform.position.y)
            {
                transform.parent = collision.gameObject.transform;
            }
        }
        if (collision.gameObject.tag == "VerMovingPlatform")
        {
            if(transform.position.y > collision.gameObject.transform.position.y)
            {
                transform.parent = collision.gameObject.transform;
            }
        }
    }

    /// <summary>
    /// Event called when a collider exits this one
    /// </summary>
    /// <param name="collision">The collision object</param>
	void  OnCollisionExit2D(Collision2D collision)
    {
        //If the colliding object is a moving platform, the player isn't a child of it any more
        if((collision.gameObject.tag == "HorMovingPlatform") || (collision.gameObject.tag == "VerMovingPlatform"))
        {
            transform.parent = null;
        }
	}

    /// <summary>
    /// Event called when a collider trigger enters this collider
    /// </summary>
    /// <param name="collider">The other collider</param>
    void OnTriggerEnter2D(Collider2D collider)
	{
        //IF the colliding object is a bouncy platform
        if(collider.gameObject.tag == "BouncyPlatform")
        {
            //Play the bounce sound and bounce the player
            audioSource.PlayOneShot(audioClips[0]);
            myRigidbody.AddForce(bounceForce);
            canJump = false;
        }
	}

    /// <summary>
    /// Builds the player out of pixels
    /// </summary>
    void BuildSelf()
	{
		for(int i = 0; i < initialNumPixels; i++)
		{
			AddPixel();
		}
	}

	/// <summary>
	/// Adds a pixel to the player's body
	/// </summary>
	void AddPixel()
	{
        //Instantiate the pixel object
		GameObject p = Instantiate(pixel, this.transform.position, this.transform.rotation) as GameObject;
		
        //Set the pixel as a child of this GameObject
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

		//Adjust the position of the pixel based on the row and column calculated
		Vector3 temp = p.transform.position;
		temp.x += column * pixelSideLength;
		temp.y += row * pixelSideLength;
		p.transform.position = temp;

        //Add the pixel to the list of pixels
		pixels.Add(p);
	}

    /// <summary>
    /// Add a pixel to the player
    /// </summary>
    /// <param name="px">The pixel to add</param>
    public void AddPixel(GameObject px)
    {
        GameObject p = Instantiate(px, transform.position, transform.rotation) as GameObject;
        p.tag = "Pixel";
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

        //Adjust the position of the pixel based on the row and column calculated
        Vector3 temp = p.transform.position;
        temp.x += column * pixelSideLength;
        temp.y += row * pixelSideLength;
        p.transform.position = temp;

        pixels.Add(p);
    }

	/// <summary>
	/// Removes a pixel from the player's body
	/// </summary>
	void RemovePixel()
	{
		if(pixels.Count > 0)
		{
			Destroy(pixels[pixels.Count - 1]);
			pixels.RemoveAt(pixels.Count - 1);

            //On player death, restart the game
			if(pixels.Count == 0)
			{
                Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	/// <summary>
	/// Handles all keyboard, mouse, and controller input
	/// </summary>
	void HandleInput()
	{
		//These inputs move the player right
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			Move(true);
		}

		//These inputs move the player left
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			Move(false);
		}

		//These inputs cause the player to jump
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			if(canJump)
			{
				Jump();
			}
		}

		//This input causes the player to shoot
		if(Input.GetKeyDown(KeyCode.Space))
		{
            if (canShoot)
            {
                Shoot();
            }
		}
	}

	/// <summary>
	/// Moves the player in the direction specified by parameter
	/// </summary>
	/// <param name="isMovingRight">If set to <c>true</c> is moving right.</param>
	void Move(bool isMovingRight)
	{
        //If the player can move, move it based on the parameter
		if(canMove)
		{
			if(isMovingRight)
			{
				Vector3 temp = myTransform.position;
				temp.x += moveVelocity;
				myTransform.position = temp;
			}
			else
			{
				Vector3 temp = myTransform.position;
				temp.x -= moveVelocity;
				myTransform.position = temp;
			}
		}
	}

	/// <summary>
	/// Causes the player to jump
	/// </summary>
	void Jump()
	{
        //Play the jump sound
		audioSource.PlayOneShot(audioClips[0]);

        //Add the jump force to the player
		myRigidbody.AddForce(jumpForce);

		canJump = false;
	}

    /// <summary>
    /// Shoots a pixel from the player
    /// </summary>
	void Shoot()
	{
        //Play the shoot sound
		audioSource.PlayOneShot(audioClips[1]);

        //Get the color from the last pixel in the list
		Color c = pixels[pixels.Count - 1].GetComponent<SpriteRenderer>().color;
		
        //Shoot from a position on the right of the player
        Vector3 instPos = myTransform.position;
        instPos.x += 2;
		instPos.y += 2;

        //Instantiate the bullet
		GameObject g = Instantiate(bullet, instPos, myTransform.rotation) as GameObject;

        //Set the sprite to the enemy pixel's sprite if necessary
        switch(pixels[pixels.Count - 1].name)
        {
            case "PlayerPixel(Clone)":
                break;
            case "EnemyPixel1(Clone)":
                g.GetComponent<SpriteRenderer>().sprite = enemyPixelSprites[0];
                break;
            case "EnemyPixel2(Clone)":
                g.GetComponent<SpriteRenderer>().sprite = enemyPixelSprites[1];
                break;
            case "EnemyPixel3(Clone)":
                g.GetComponent<SpriteRenderer>().sprite = enemyPixelSprites[2];
                break;
        }

		g.GetComponent<SpriteRenderer>().color = c;

        //Remove a pixel from the player
		RemovePixel();
	}

    /// <summary>
    /// Damage the player
    /// </summary>
    /// <param name="enemyDamage">The amount of damage to deal</param>
	public IEnumerator Hit(int enemyDamage)
	{
        //The player is invulnerable for a short time after being hit
		invulnerable = true;

        //Remove pixels equal to the amount of damage dealt
		for(int i = 0; i < enemyDamage; i++)
		{
			RemovePixel();
		}

        //Wait for invulnerability time
		yield return new WaitForSeconds(invulnerabilityTimeAfterCollision);

        //No longer invulnerable
		invulnerable = false;
	}
}
