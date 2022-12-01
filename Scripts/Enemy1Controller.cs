using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    public static Enemy1Controller instance;

    public Transform leftPoint;
    public Transform rightPoint;

    public float moveTime, moveCounter;
    public float stopTime, stopCounter;

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
    }

    // Update is called once per frame
    void Update()
    {
        StopAndMove();
        ChangeDirection();
    }

    private void EnemyMove()
    {
        if(movingLeft)
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
        if(moveTime > 0)
        {
            EnemyMove();
            moveTime -= Time.deltaTime;
        }
        else
        {
            theRB.velocity = new Vector2(0, 0);
            if (stopTime > 0)
            {
                stopTime -= Time.deltaTime;
            }
            else
            {
                stopTime = stopCounter * Random.Range(0.5f, 1.5f);
                moveTime = moveCounter * Random.Range(0.5f, 1.5f);
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

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Hit player");
            HealthController.instance.DealDamage();
        }
    }
}



