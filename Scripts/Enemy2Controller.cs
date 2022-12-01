using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public static Enemy2Controller instance;

    public Transform leftPoint;
    public Transform rightPoint;

    public float moveTime, moveCounter;
    public float stopTime, stopCounter;

    public Transform shootingPoint1, shootingPoint2, shootingPoint3;
    public int shootCounter, shotsAllowed;
    public GameObject theBullet;

    public float moveSpeed;

    private bool movingLeft;

    public Rigidbody2D theRB;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;

        leftPoint.parent = null;
        rightPoint.parent = null;

        shootCounter = shotsAllowed;
    }

    // Update is called once per frame
    void Update()
    {
        StopAndMove();
        ChangeDirection();
    }

    private void EnemyMove()
    {
        if (movingLeft)
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

        }
        else
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
    }

    private void StopAndMove()
    {
        if (moveTime > 0)
        {
            EnemyMove();
            moveTime -= Time.deltaTime;
        }
        else
        {
            theRB.velocity = new Vector2(0, 0);
            if (stopTime > 0)
            {
                if(shootCounter > 0)
                {
                    //Debug.Log("Shoot");
                    shootCounter--;
                    Instantiate(theBullet, shootingPoint1.position, shootingPoint1.rotation);
                    Instantiate(theBullet, shootingPoint2.position, shootingPoint2.rotation);
                    Instantiate(theBullet, shootingPoint3.position, shootingPoint3.rotation);


                }
                stopTime -= Time.deltaTime;
            }
            else
            {
                stopTime = stopCounter * Random.Range(0.5f, 1.5f);
                moveTime = moveCounter * Random.Range(0.5f, 1.5f);
                shootCounter = shotsAllowed;
            }
        }

    }


    private void ChangeDirection()
    {
        if (theRB.position.x < leftPoint.position.x)
        {
            //Debug.Log("Change direction");
            movingLeft = false;
        }
        else if (theRB.position.x > rightPoint.position.x)
        {
            movingLeft = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Hit player");
            HealthController.instance.DealDamage();
        }
    }
}
