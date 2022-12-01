using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //This create an instance of the class which allow other class to referece this class vairables and methods
    public static Boss instance;
    
    //This float will be use to preset the boss first and second health bar to 200
    public float bossMaxHealth = 200f;
    //This float will be use to keep track of the boss health at all time
    public float bossCurrentHealth;

    //This bool will be used to check if the boss is currently active or not
    public bool isBossActive;
    //This bool will be used to keep track if the boss is in phase 1 or not
    public bool isPhase1 = false;
    //This bool will be used to keep track if the boss is in phase 2 or not
    public bool isPhase2 = false;

    //This variable hold reference to the blueHealthBar game object, which is the health bar of phase 1
    public GameObject blueHealthBar;
    //This variable hold reference to the purpleHealthBar game object, which is the health bar of phase 2
    public GameObject purpleHealthBar;
    //This variable hold reference to the barFrame game object, which is the outer frame used for both health bar
    public GameObject barFrame;
    //This variable hold reference to the bossName game object, which is the name of the boss
    public GameObject bossName;
    //This variable hold reference to the SpriteRenderer component attached to the health bar
    public SpriteRenderer theSR;
    //This float is used ot keep the current time that the player has been fighting the boss for
    public float time;
    //This float is used to make a copy of the time at the moment the boss is killed.
    public float finishedTime;
    //This bool is used to make sure that the reward spawned for defeating the boss only spawned once
    public bool rewardSpawn = true;
    //This variable hold reference to the gem game object stored in the prefab.
    public GameObject gems;
    //This is a float
    public float a = 0f;
    //These 5 variables store the transform position of the points with its corresponding names
    public Transform originalPointLeft, originalPointRight;
    public Transform sideAreaLef;
    public Transform centerClapPoint;
    //These bools keep track of which attack the boss is performing.
    public bool isAttack1 = false, isAttack2 = false, isAttack3=false;
    //This array store all the transforms of the position that the hands will be moving through for attack 1
    public Transform[] leftPoints;
    //This float store the attackSpeed of the hand of the boss
    public float attackSpeed;
    //This integer acts as a pointer for the boss to keep track of which point it needs to go to next from the array
    public int currentPoint;
    //These 2 variables store the reference to the rigidbody components that are attached to the left and right hand objects
    public Rigidbody2D leftHand, rightHand;
    //This stores the transform position of the point to attack, or point fo rhte hands to move towards for attack 2
    public Transform pointToAttack;
    //These bools are used to keep track of the action being performed for attack 2
    //isPositionSet is used to check if the Transform of the pointToAttack is set to the player's position
    //isLeftHandAttack and isRightHandAttack are use by the boss to decide which hand it should use to attack the player for attakc 2
    //isHandDecided is used to make sure the which hand to use decision is only made once
    public bool isPositionSet, isLeftHandAttack, isRightHandAttack, isHandDecided;
    //These variables store the transform positions that is used to summon minons for attack 3
    public Transform pointSummon1, pointSummon2, pointSummon3, pointSummon4;
    //These variables store reference to the enemies from the prefab, ready to be instantiate.
    public GameObject enemy1_left, enemy1_right, enemy2_left, enemy2_right;

    //This bool is used to keep track of if the boss is lowering its head.
    public bool isBossDown;
    //This bool is used to ensure that the boss only perform 1 attack at a time 
    public bool isAttacking;
    //These variables store the transform positions of the points that the head will move between
    public Transform originalHeadPoint, descendingPoint, theHeadPos;
    //This variable is refercing to the rigidbody component attached to the head of the boss, in order to move it
    public Rigidbody2D theHeadRB;
    //This float store the speed that the head will be moving at
    public float headMoveSpeed = 10f;
    //These 2 bools are used to keep track of if the head of the boss is moving up or down
    public bool headMovingDown, headMovingUp;

    //This method is called upon the object is initialized
    void Awake()
    {
        //Setitng instance equal to this create a reference of this class for other classes
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Starting of by setting the boss health bar once for phase 1
        bossCurrentHealth = bossMaxHealth;
        //Time is set to zero, this is reseting the timer
        time = 0f;
        //This bool is set to true, indicating hte boss is active and ready to attack
        isBossActive = true;
        //the isPhase1 bool will be set to true as the boss will begin with phase 1
        isPhase1 = true;
        //isPhase2 is switched off to ensure non of the Phase 2 code will run
        isPhase2 = false;

        //Setting all of these bools to false to ensure that the boss will make no action on start
        isAttacking = false;
        isAttack1 = false;
        isAttack2 = false;
        isAttack3 = false;
        isBossDown = false;

        //Here I will start the Coroutine that moves the head for first time.
        StartCoroutine(WaitToMoveHead());
    }
    //This method will be call once every frame
    void Update()
    {
        //This will increase time accordingly to the time in real life
        time = time + Time.deltaTime;

        //The code below will run if the boss health get reduced to below 0
        if(bossCurrentHealth < 0)
        {
            //This the boss is in phase 1 then the code below will run. Now the boss will change phase
            if(isPhase1)
            {
                //Phase1 bool is switch off
                isPhase1 = false;
                //The boss health will be replenish to the max which is set to 200f
                bossCurrentHealth = bossMaxHealth;
                //The blue health bar will be switch off
                blueHealthBar.SetActive(false);
                //In its place, the purple bar will be switch on
                purpleHealthBar.SetActive(true);
                //This will access the colour of the sprite of the boss and tune it so that the boss change to a purple-ish colour
                theSR.color = new Color(225, 0, 205, 1f);
                //This will switch the boss to phase2, which allow phase 2 code to run.
                isPhase2 = true;
            }
            //Else if the boss in phase 2 then the code below will run. Now the boss will be dead
            else if(isPhase2)
            {
                //The boss health is reset again for the next run.
                bossCurrentHealth = bossMaxHealth;
                //Then the boss will be disable
                isBossActive =false;
                //The boss health bar frame will be disable 
                barFrame.SetActive(false);
                //The boss name will be disable
                bossName.SetActive(false);
                //The purple health bar will be disable
                purpleHealthBar.SetActive(false);
                //Now the finished time will make a copy of the moment the boss died
                finishedTime = time;
                //This will call the StopMusic() method from the AudioManager class, 5, this will stop the boss battle music
                AudioManager.instance.StopMusic(5);
                //This will call the PlayMusic() method from the AudioManager class, 6, this will play regular background music
                AudioManager.instance.PlaySound(4);

                //This will now set the bool isGameOver form the GameOverPanel class to true.
                GameOverPanel.instance.isGameOver = true;
                //Now the boss game object will be destroy.
                Destroy(gameObject);

                
                //Now if the rewardSpawn bool is true then the code below will run. Which should be as it is set so from the start
                if (rewardSpawn == true)
                {
                    //Here I am creating the first factor that contibute a rnadomly amount of gem rewards, which will take mod 60 of the finshed time
                    float factor1 = finishedTime % 60;
                    //Here I am creating the second factor that contibute a rnadomly amount of gem rewards, which will tkae 20% of the health that the player has left
                    float factor2 = HealthController.instance.currentHealth % 20;

                    //Then I will add the 2 factor together effectively rewarding the player more gems if they finihsed with less time and more health
                    float noGemToSpawn = factor1 + factor2;

                    //Then this loop is called the number of gems rewards times to spawned in all the gems
                    for (int i = 0; i < noGemToSpawn; i++)
                    {
                        //Debug.Log(i);
                        //The postion that the gems will be spawning in needs to change so they dont all overlap over 1 point.
                        Instantiate(gems,transform.position + new Vector3 (a, a, a), transform.rotation);
                        //Variable a keep the position that the gem spawned are apart from each other.
                        a = a + 0.1f;
                    }
                    //After all gems have been spawned, the bool rewardSpawn is switched to off to stop any more gems from spawning
                    rewardSpawn = false;
                }
            }
        }
        //This will start the Coroutine WaitForNextMove()
        StartCoroutine(WaitForNextMove());

        //This Coroutine will decide which attack the boss should perform next.
        IEnumerator WaitForNextMove()
        {
            //If the boss is not attacking then the code below will be run
            if (!isAttacking)
            {
                //This will set isAttacking to true, allowing the boss to perform attack
                isAttacking = true;
                //It will wait for 1.5 seconds before making a decision
                yield return new WaitForSeconds(1.5f);
                //The boss will then make a choice between 1 and 4
                int choice = Random.Range(1, 4);
                //This is a switch case which indicate what will happen for each case
                switch (choice)
                {
                    //If the choice is 1 then 
                    case 1:
                        //The boss will perform attack 1
                        isAttack1 = true;
                        //This is done by setting the currentPoint, which will set the point the hands to move between
                        currentPoint = 0;
                        //Then break, end case
                        break;
                    //If the choice is 2 then
                    case 2:
                        //The boss will perform attack 2
                        isAttack2 = true;
                        //This will switch postion set and hadn decided to true to allow the position to be set once and the hand to be selected onces
                        isPositionSet = true;
                        isHandDecided = true;
                        //Then break, end case
                        break;
                    //If the choice is 3 then
                    case 3:
                        //The boss will perform attack 3, which it will spawn in its minions
                        isAttack3 = true;
                        //Then break, end case.
                        break;
                }
            }
        }

        if (headMovingDown)
        {
            theHeadRB.velocity = new Vector2(0, -headMoveSpeed);
            if (theHeadPos.position.y < descendingPoint.position.y)
            {
                headMovingDown = false;
                theHeadRB.velocity = new Vector2(0, 0);
                StartCoroutine(WaitToMoveHead());
            }
        }
        else if(headMovingUp)
        {
            theHeadRB.velocity = new Vector2(0, headMoveSpeed);
            if(theHeadPos.position.y > originalHeadPoint.position.y)
            {
                headMovingUp = false;
                theHeadRB.velocity = new Vector2(0, 0);
                StartCoroutine(WaitToMoveHead());
            }
        }



        if (!isAttack1)
        {
            StopMovement();
        }

        attackSpeed = 10;

        if (isAttack1)
        {
            if (leftHand.position.x > leftPoints[currentPoint].position.x)
            {
                leftHand.velocity = new Vector2(-attackSpeed, leftHand.velocity.y);
                rightHand.velocity = new Vector2(attackSpeed, rightHand.velocity.y);
                DistanceCheck();
            }
            else
            {
                leftHand.velocity = new Vector2(attackSpeed, leftHand.velocity.y);
                rightHand.velocity = new Vector2(-attackSpeed, rightHand.velocity.y);
                DistanceCheck();
            }
            if (leftHand.position.y > leftPoints[currentPoint].position.y)
            {
                leftHand.velocity = new Vector2(leftHand.velocity.x, -attackSpeed / 4);
                rightHand.velocity = new Vector2(rightHand.velocity.x, -attackSpeed / 4);
                DistanceCheck();
            }
            else
            {
                leftHand.velocity = new Vector2(leftHand.velocity.x, attackSpeed / 4);
                rightHand.velocity = new Vector2(rightHand.velocity.x, attackSpeed / 4);
                DistanceCheck();

            }

        }

        if (isAttack2)
        {
            if (isPositionSet == true)
            {
                float x = PlayerController.instance.playerPoint.position.x;
                float y = PlayerController.instance.playerPoint.position.y;
                float z = PlayerController.instance.playerPoint.position.z;
                pointToAttack.position = new Vector3(x, y, z);

                isPositionSet = false;
            }

            if (isHandDecided == true)
            {
                isRightHandAttack = false;
                isLeftHandAttack = false;

                if (pointToAttack.position.x > rightHand.position.x)
                {
                    isRightHandAttack = true;
                }
                else if (pointToAttack.position.x < leftHand.position.x)
                {
                    isLeftHandAttack = true;
                }
                else if (pointToAttack.position.x - leftHand.position.x < rightHand.position.x - pointToAttack.position.x)
                {
                    isLeftHandAttack = true;
                }
                else if (pointToAttack.position.x - leftHand.position.x > rightHand.position.x - pointToAttack.position.x)
                {
                    isRightHandAttack = true;
                }

                isHandDecided = false;
            }

            if (isLeftHandAttack)
            {
                MoveHand(leftHand);
                DistanceCheck();
            }
            else
            {
                MoveHand(rightHand);
                DistanceCheck();
            }

            void MoveHand(Rigidbody2D armName)
            {
                if (armName.position.x > pointToAttack.position.x)
                {
                    armName.velocity = new Vector2(-attackSpeed, armName.velocity.y);
                }
                else if (armName.position.x < pointToAttack.position.x)
                {
                    armName.velocity = new Vector2(attackSpeed, armName.velocity.y);
                }
                if (armName.position.y > pointToAttack.position.y)
                {
                    armName.velocity = new Vector2(armName.velocity.x, -attackSpeed);
                }
                else if (armName.position.y < pointToAttack.position.y)
                {
                    armName.velocity = new Vector2(armName.velocity.x, attackSpeed);
                }
            }
        }

        if(isAttack3)
        {
            if(isPhase1)
            {
                Instantiate(enemy1_left, pointSummon1.position, pointSummon2.rotation);
                Instantiate(enemy1_right, pointSummon2.position, pointSummon2.rotation);
            }
                
            if(isPhase2)
            {
                Instantiate(enemy1_left, pointSummon1.position, pointSummon2.rotation);
                Instantiate(enemy1_right, pointSummon2.position, pointSummon2.rotation);
                Instantiate(enemy2_left, pointSummon3.position, pointSummon3.rotation);
                Instantiate(enemy2_right, pointSummon4.position, pointSummon4.rotation);
            }

            isAttack3 = false;
            isAttacking = false;
        }

        void StopMovement()
        {
            leftHand.velocity = new Vector2(0, 0);
            rightHand.velocity = new Vector2(0, 0);
        }

        void DistanceCheck()
        {
            if (isAttack1)
            {
                if (Vector3.Distance(leftHand.position, leftPoints[currentPoint].position) < 0.15f)
                {
                    if (currentPoint < leftPoints.Length - 1)
                    {
                        currentPoint++;
                    }
                    else
                    {
                        leftHand.velocity = new Vector3(0f, 0f, 0f);
                        isAttack1 = false;
                        StopMovement();
                        isAttacking = false;
                    }
                }
            }

            else if (isAttack2)
            {
                if (isLeftHandAttack && Vector3.Distance(leftHand.position, pointToAttack.position) < 0.5f)
                {
                    if (pointToAttack.position.x != originalPointLeft.position.y && pointToAttack.position.y != originalPointLeft.position.y)
                    {
                        pointToAttack.position = originalPointLeft.position;
                    }
                    else
                    {
                        leftHand.velocity = new Vector3(0, 0, 0);
                        isLeftHandAttack = false;
                        isAttack2 = false;
                        StopMovement();
                        isAttacking = false;
                    }
                }
                else if (isRightHandAttack && Vector3.Distance(rightHand.position, pointToAttack.position) < 0.5f)
                {
                    if (pointToAttack.position.x != originalPointRight.position.y && pointToAttack.position.y != originalPointRight.position.y)
                    {
                        pointToAttack.position = originalPointRight.position;
                    }
                    else
                    {
                        rightHand.velocity = new Vector3(0, 0, 0);
                        isRightHandAttack = false;
                        isAttack2 = false;
                        StopMovement();
                        isAttacking = false;
                    }
                }
            }
        }
    }
    //This Coroutine will be monitoring the movement up and down of the boss's head.
    IEnumerator WaitToMoveHead()
    {
        //The program will wait for 1 second before running.
        yield return new WaitForSeconds(1f);
        //Then a choice been 1 and 3 is made
        int choice = Random.Range(1, 3);
        //IF the choice is 1 then the head will be moving up, or stay up
        if (choice == 1)
        {
            //This switcht the bool to move the head up to true
            headMovingUp = true;
        }
        //If the choice is 2 or 3, then the boss head will be moving down, or stay down
        else
        {
            //This switcht the bool to move the head down to true
            headMovingDown = true;
        }
    }
}