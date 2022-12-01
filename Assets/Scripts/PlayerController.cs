using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    // Creating a variable called "moveSpeed" ; public means that will be able to access in the Unity editor ; float is the data type of this variable
    public float moveSpeed;
    // Rigidbody2D is the name of the component that controls the PO physics
    public Rigidbody2D theRB;
    //This force will control how high the player can jump
    public float jumpForce;

    //The jump Counter will monitor the amount of jump the player can perform in a row
    private int jumpCounter;
    //the jumpAllowed will reset the jumpCounter when the player lands
    public int jumpsAllowed;

    //This transform store the x,y,z position of the player.
    public Transform playerPoint;

    //This store the x,y,z location of the point where the attack is going to be Instantiate
    public Transform attackPoint;
    //This store the reference to the slash in the prefab
    public GameObject theSlash;

    //This store the reference the player's gameobject
    public GameObject thePlayer;
    //this store the x,y,z location of the Camera object
    public Transform theCamera;
    //This float will be use for a countdown
    public float timeToWait;

    //This bool will be use to send signal appear of the gameover algorithm
    public bool playerDeath;

    public float dashForce;

    private bool ableToDash = true;
    private bool isDashing;
    private float dashingPower = 15f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 3f;

    //This method will be called once at the moment the script is instantiate
    void Awake()
    {
        //Makign instance equal to this object
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //This will set the jump couter to max at the start of the level
        jumpCounter = jumpsAllowed;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }

        //Calling the PlayerMove() method, allowing the player to move
        PlayerMove();
        //Calling the Jump() method, allowing the player to jupm
        Jump();
        //calling the killPlayer() method, performing constant check if the player has died or not
        killPlayer();

    }

    //This built-in mehtod is used to check for collision of the box collider component
    private void OnCollisionEnter2D(Collision2D other)
    {
        //If the player collide with another collider with the tag "Ground" then
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("Touch ground");

            //The jumpCounter gets reset
            jumpCounter = jumpsAllowed;
        }
    }

    //This method will allow the player to move around and perform attacks
    private void PlayerMove()
    {
        if(isDashing)
        {
            return;
        }

        // veloity controls the speed of an object ; Vector2 is a variable that store the x and y value of the object
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        //Code below will run if the key "J" is pressed
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log("Attack!");
            
            //Instantiate is a built-in method that let me creata a copy of an object from the prefab with at the position and roation as reference to the varibles declared above
            Instantiate(theSlash, attackPoint.position, attackPoint.rotation);

        }

        //Code below will run if the key "A" is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("Turn left");
            
            //This is changing the local scale of the player, which simple would turn the player and any obejct attached to it by 180 degree by the y axis nad facing to the left
            playerPoint.localScale = new Vector3(-1f, 1f, 1f);

        }
        //Code below will run if the keu "D" is pressed
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Turn right");

            //Just like above but opposite, the player will be spin 180 again and be facing to the riht now 
            playerPoint.localScale = new Vector3(1f, 1f, 1f);
        }

        //the point of this is to allow the attack point to be facing the direction of travel of player

        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
    }


    private IEnumerator Dash()
    {
        ableToDash = false;
        isDashing = true;
        float orginalGravity = theRB.gravityScale;
        theRB.gravityScale = 0f;
        theRB.velocity = new Vector2(transform.localScale.x * dashingPower, 1f);
        yield return new WaitForSeconds(dashingTime);
        theRB.gravityScale = orginalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        ableToDash = true;
    }

    //This method will hold the algorithm that allow the player to jump
    private void Jump()
    {
        //The code will run if the the Jump button is pressed, in this case is the SPACEBAR.
        if (Input.GetButtonDown("Jump") && jumpCounter > 0)
        {
            //Debug.Log("JUMP!");

            //This apply the force on the rigid body component which will make the player object jumps
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);

            //Decreasing hte counter by one after a jump is completed.
            jumpCounter--;
        }

    }

    //This method will kill the player if the following condition is true
    private void killPlayer()
    {
        //This condition call the method DeathCheck() from the healthController class.
        if (HealthController.instance.DeathCheck() == true)
        {
            //Debug.Log("PlayerDeath");

            //This will detach the cmaera from the player object before being delete
            theCamera.parent = null;

            //This will call the PlaySound method from the Audio Manager, the sound number 6 is the death sound effect
            AudioManager.instance.PlaySound(6);

            //This will destroy the player object
            Destroy(gameObject);

            //This will now set the bool isGameOver form the GameOverPanel class to true.
            GameOverPanel.instance.isGameOver = true;
        }

    }
    
}
    