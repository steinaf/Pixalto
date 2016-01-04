using UnityEngine;
using System.Collections;

public class LevelNextTrigger : MonoBehaviour
{
    //Public variables
    public Font pixelFont;
    
    //Private variables
    bool bDisplay = false;
    int enemiesLeftAlive;
    int enemiesBefriended;
    public GameObject nextLevelStartPoint;
    GameObject player;
    string statisticsText;

    // Use this for initialization
    void Start()
    {
        //Find the player GameObject
        player = GameObject.FindGameObjectWithTag("Player");

        statisticsText = "";
        enemiesLeftAlive = 0;
        enemiesBefriended = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //If text is displaying and the enter key is down, go to the next level
        if(bDisplay && Input.GetKeyDown(KeyCode.Return))
        {
            if (transform.parent.name != "EndGame")
            {
                bDisplay = false;
                player.transform.position = nextLevelStartPoint.transform.position;
                player.GetComponent<Player>().CanMove = true;
                player.GetComponent<Player>().CanJump = true;
                player.GetComponent<Player>().CanShoot = true;

                //Add pixels to player
                Enemy[] enemiesAlive = transform.parent.gameObject.GetComponentsInChildren<Enemy>();
                foreach (Enemy e in enemiesAlive)
                {
                    player.GetComponent<Player>().AddPixel(e.pixelTypes[e.PixelType]);

                    if (e.Befriended)
                    {
                        player.GetComponent<Player>().AddPixel(e.pixelTypes[e.PixelType]);
                    }
                }
            }
            //Or quit the game if you're at the end state
            else
            {
                Application.Quit();
            }
        }
    }

    /// <summary>
    /// Event that is called when this GameObject's collider is triggered by being enterd by another one
    /// </summary>
    /// <param name="other">The collider colliding with this one</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //If the other's tag is Pixel, pause the player and count enemies left alive
        if (other.tag == "Pixel")
        {
            bDisplay = true;
            player.GetComponent<Player>().CanMove = false;
            player.GetComponent<Player>().CanJump = false;
            player.GetComponent<Player>().CanShoot = false;

            enemiesLeftAlive = 0;
            enemiesBefriended = 0;

            Enemy[] enemiesAlive = transform.parent.gameObject.GetComponentsInChildren<Enemy>();
            foreach (Enemy e in enemiesAlive)
            {
                enemiesLeftAlive++;
                if(e.Befriended)
                {
                    enemiesBefriended++;
                }
            }
        }
    }

    /// <summary>
    /// Called every time the screen is refreshed, possibly multiple times per frame
    /// </summary>
    void OnGUI()
    {
        //If text is displaying, format and display it
        if(bDisplay)
        {
            //Set font and color
            GUIStyle myStyle = new GUIStyle();
            myStyle.font = pixelFont;
            myStyle.normal.textColor = Color.white;

            //End level text
            if (transform.parent.name != "EndGame")
            {
                statisticsText = "Level complete!\n\n" + enemiesLeftAlive + " NPC(s) left alive\n\n" + enemiesBefriended + " NPC(s) befriended\n\n" + (enemiesLeftAlive + enemiesBefriended) + " pixel(s) gained\n\n" + "Press enter to continue...";
            }
            //End game text
            else
            {
                SpriteRenderer[] playerPixels = player.GetComponent<Player>().GetComponentsInChildren<SpriteRenderer>();
                float origPlayerRemainingPixels = 0f;
                foreach(SpriteRenderer s in playerPixels)
                {
                    if(s.gameObject.name == "PlayerPixel(Clone)")
                    {
                        origPlayerRemainingPixels++;
                    }
                }
                float selfRemainingPercentage = (origPlayerRemainingPixels / (float)player.GetComponent<Player>().initialNumPixels) * 100f;
                float roundedSelfRemainingPercentage = Mathf.Round(selfRemainingPercentage * 10f) / 10f;

                float growthPercentage = (((float)playerPixels.Length - (float)player.GetComponent<Player>().initialNumPixels) / (float)player.GetComponent<Player>().initialNumPixels) * 100f;
                float roundedGrowthPercentage = Mathf.Round(growthPercentage * 10f) / 10f;

                statisticsText = "Game complete!\n\n" + "Remaining self: " + roundedSelfRemainingPercentage + "%\n\n" + "Growth: " + roundedGrowthPercentage + "%\n\n" + "Press enter to quit...";
            }
            
            //Draw text
            GUI.TextArea(new Rect(Screen.width / 3, 3 * Screen.height / 5, Screen.width / 4, Screen.height / 4), statisticsText, myStyle);
        }
    }
}