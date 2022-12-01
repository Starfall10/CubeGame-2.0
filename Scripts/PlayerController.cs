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
    public float jumpForce;

    private int jumpCounter;
    public int jumpsAllowed;

    public Transform playerPoint;

    public Transform attackPoint;
    public GameObject theSlash;

    public GameObject thePlayer;
    public Transform theCamera;
    public float timeToWait;

    public bool playerDeath;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpCounter = jumpsAllowed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Jump();
        killPlayer();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("Touch ground");
            jumpCounter = jumpsAllowed;
        }
    }

    private void PlayerMove()
    {
        // veloity controls the speed of an object ; Vector2 is a variable that store the x and y value of the object
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log("Attack!");
            Instantiate(theSlash, attackPoint.position, attackPoint.rotation);

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("Turn left");
            playerPoint.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Turn right");
            playerPoint.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCounter > 0)
        {
            //Debug.Log("JUMP!");
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);

            jumpCounter--;
        }

    }

    private void killPlayer()
    {
        if (HealthController.instance.DeathCheck() == true)
        {
            //Debug.Log("PlayerDeath");
            theCamera.parent = null;

            Destroy(gameObject);

            GameOverPanel.instance.isGameOver = true;
        }

    }
    

    
    
}
    