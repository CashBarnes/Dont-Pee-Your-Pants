using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float  moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;
    public float jumpTime;
    //comment out if you don't want double jump
    public float doubleJumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    private bool canDoubleJump;
    
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    public GameManager theGameManager;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    public GameObject pauseButton;

    public Text deathText;
    

    //private Collider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        //gets the box collider for the ground elements. Must be assiged "Ground" layer.
        //myCollider = GetComponent<BoxCollider2D>();
        //gets the animator for the character. Comment out if not using animations.
        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        //speed up when you get further
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }
        
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpSound.Play();
            }
            if(!grounded && canDoubleJump)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                //comment out if you don't want double jump
                jumpTimeCounter = doubleJumpTime;
                stoppedJumping = false;
                //comment out if you don't want double jump
                canDoubleJump = false;
                jumpSound.Play();
            }
        }

        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if(jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if(grounded)
        {
            jumpTimeCounter = jumpTime;
            //comment out if you don't want double jump
            canDoubleJump = true;
        }

        myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool ("Grounded", grounded);
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {   
            deathText.text = "You died! Be careful near cliffs!";
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            deathSound.Play();
            pauseButton.SetActive(false);
        }
        else if(other.gameObject.tag == "cactus")
            {
                deathText.text = "You hit a cactus! Those are dangerous!";
                theGameManager.RestartGame();
                moveSpeed = moveSpeedStore;
                speedMilestoneCount = speedMilestoneCountStore;
                speedIncreaseMilestone = speedIncreaseMilestoneStore;
                deathSound.Play();
                pauseButton.SetActive(false);
            }
    }
}
