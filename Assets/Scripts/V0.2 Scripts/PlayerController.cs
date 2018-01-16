using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Takes hotkey inputs and moves player accordingly.
 */
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    public float accSpeed = 15f;
    public bool canJump;
    public bool canFall;
    public int deaths;
    public Text deathCount;
    public GameObject shotSpawn;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float jumpDelay;
    public float fallDelay;

    float tempMoveSpeed; //Keeps Value of base move speed
    float jumpDelayCounter;
    float fallDelayCounter;
    BoxCollider2D bc;
    Rigidbody2D rb;
    Animator playerAC;
    bool crouching;

    [HideInInspector] public bool isFliped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        playerAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement

        //Player press A, MoveLeft
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        //Stops Left movement after letting go of A
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //Player press D, Move right
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        //Stops right movement after letting go of D
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //Jump
        if (Input.GetButtonDown("Jump") && canJump && !Input.GetKey(KeyCode.S) && Time.time > jumpDelayCounter)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            jumpDelayCounter = Time.time + jumpDelay;
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //JumpDown
        if (Input.GetKey(KeyCode.Space) && canJump && Input.GetKey(KeyCode.S) && canFall)
        {
            bc.isTrigger = true;
            jumpDelayCounter = Time.time + jumpDelay;
        }

        //
        if (bc.isTrigger && Time.time > fallDelayCounter)
        {
            bc.isTrigger = false;
            fallDelayCounter = Time.time + fallDelay;
        }

        //Run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            tempMoveSpeed = moveSpeed;
            moveSpeed = accSpeed;
        }
        //Returns movespeed to default
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = tempMoveSpeed;
        }

        print(rb.velocity);
        Animating();

    }

    void Animating()
    {
        // Crouch
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAC.SetBool("isCrouching", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAC.SetBool("isCrouching", false);
        }

        //Flip, turn around
        if (rb.velocity.x < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            playerAC.SetBool("isFlipped", true);
            isFliped = true;
        }

        //Stops player from flipping if aiming back
        if (rb.velocity.x < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            playerAC.SetBool("isFlipped", false);
            isFliped = false;
        }

        //Aim up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAC.SetBool("isAimingUp", true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerAC.SetBool("isAimingUp", false);
        }

        //Aim down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAC.SetBool("isAimingDown", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAC.SetBool("isAimingDown", false);
        }

        //aim back
        if (isFliped)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerAC.SetBool("isAimingBack", true);
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerAC.SetBool("isAimingBack", false);
            }
        }
        else if (!isFliped)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerAC.SetBool("isAimingBack", true);
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerAC.SetBool("isAimingBack", false);
            }
        }
    }
}
