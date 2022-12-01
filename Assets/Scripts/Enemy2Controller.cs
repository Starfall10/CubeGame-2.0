using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    //This create an instance of the class which allow other class to referece this class vairables and methods
    public static Enemy2Controller instance;

    //Creating 2 variables that stores the x,y,z, location of 2 points that the enemy will be moving between
    public Transform leftPoint;
    public Transform rightPoint;

    //These 2 variables will store the time that the enemy will move before stopping. The moveTime will decrease over time and the moveCounter will be used to reset the moveTime
    public float moveTime, moveCounter;
    //These 2 variables will store the time that the enemy will stop before moving. The stopTime will decrease over time and the stopCounter will be used to reset the stopTime
    public float stopTime, stopCounter;

    //These 3 variables will store the x,y,z locations of the 3 points that I will be use to be spawn in the bullets
    public Transform shootingPoint1, shootingPoint2, shootingPoint3;
    //These will make sure that the enemy will be shooting once after stopping
    public int shootCounter, shotsAllowed;
    //This stores the gameObject of the bullet that will be instantiate later by the enemy
    public GameObject theBullet;

    //This variable store the movement speed that the enemy will move at
    public float moveSpeed;
    //This boolean is used to determine if the enemy is moving left or right
    private bool movingLeft;
    //This store the component rigidbody of enemy. I will need to apply force to theRB to make the enemy moves
    public Rigidbody2D theRB;

    //This method is called upon the object is initialized
    void Awake()
    {
        //Setitng instance equal to this create a reference of this class for other classes
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Setting the movingLeft bool to true
        movingLeft = true;

        //Detaching the leftPoint and rightPoint GameObject from the enemy GameObject
        leftPoint.parent = null;
        rightPoint.parent = null;

        //Setting the number of shots allowed
        shootCounter = shotsAllowed;
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the StopAndMove() method once every frame
        StopAndMove();
        //Calling the ChangeDirection() method once every frame
        ChangeDirection();
    }

    //This method will control the movement of the enemy
    private void EnemyMove()
    {
        //If the movingLeft bool is true then
        if (movingLeft)
        {
            // The move speed will be applied as negative on the x-axis to make the enemy move left and the y-axis will remain the same to stop the enemy to be moving up and down
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

        }
        //If the movingLeft bool is not true then
        else
        {
            // The move speed will be applied as positive on the x-axis to make the enemy move right and the y-axis will remain the same to stop the enemy to be moving up and down
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
    }

    //This method will monitor and control when the enemy should be moving and when it should be stoppin
    private void StopAndMove()
    {
        //If moveTime larger than 0 then
        if (moveTime > 0)
        {
            //The enemy will move by calling this method
            EnemyMove();
            //Time.deltaTime is used to decrease the moveTime relative to real life time
            moveTime -= Time.deltaTime;
        }
        //If moveTime is less than 0 then
        else
        {
            //The enemy will be made to stop immediately
            theRB.velocity = new Vector2(0, 0);
            //Then if stop time is larger than 0 then the enemy will not be moving
            if (stopTime > 0)
            {
                if(shootCounter > 0)
                {
                    //Debug.Log("Shoot");
                    shootCounter--;
                    //These 3 lines will create 3 new bullet objects, each one will spawn at the 3 locations respectively
                    Instantiate(theBullet, shootingPoint1.position, shootingPoint1.rotation);
                    Instantiate(theBullet, shootingPoint2.position, shootingPoint2.rotation);
                    Instantiate(theBullet, shootingPoint3.position, shootingPoint3.rotation);


                }
                //Just like the moveTime, stopTime will be decreasing according to real life time aswell
                stopTime -= Time.deltaTime;
            }
            else
            {
                //both the stopTime and moveTime will reset
                //Multiplying the Counter will random will make the movement of the enemy more unpredictable
                stopTime = stopCounter * Random.Range(0.5f, 1.5f);
                moveTime = moveCounter * Random.Range(0.5f, 1.5f);
                //Reseting the number of shots the enemy can perform
                shootCounter = shotsAllowed;
            }
        }

    }

    //This method will motitor the change of direction of the enemy
    private void ChangeDirection()
    {
        //The code will run if the enemy has pass the leftPoint
        if (theRB.position.x < leftPoint.position.x)
        {
            //Debug.Log("Change direction");

            //The bool is set to false
            movingLeft = false;
        }
        //The code will run if the enemy has pass the rightPoint
        else if (theRB.position.x > rightPoint.position.x)
        {
            //The bool is set to true
            movingLeft = true;
        }
    }

    //This method will check if the enemy has collided with any object
    private void OnCollisionEnter2D(Collision2D other)
    {
        //If the collided object has the "Player" tag then
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Hit player");

            //The DealDamage() method from the HealthController class will be call to damage the player
            HealthController.instance.DealDamage();
        }
    }
}
