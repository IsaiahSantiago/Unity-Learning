using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWASD : MonoBehaviour
{
    public float speed = 5;
    //will store our direction
    private Vector3 dir;
    private Rigidbody2D rb2d;

    //Adding a Boolean for Jumping
    private bool isJumping = false;
    public bool canJump = true;
    public float jumpForce = 5;





    // Start is called before the first frame update
    void Start()
    {
        //get Rigid body script off of object that it's attached to, Store it in our "rb2d" Variable
        rb2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    //update is good for UI, Player input
    void Update()
    {
        /*We are calling our Direction function
        that returns a vector   
        & we're storing it in Dir
        */
        dir = Direction();

        transform.Translate(dir * speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.Space))
            //getkeydown is like keyispressed
        {
            Debug.Log("Pressed Space");

            isJumping = true;
            Debug.Log("Is Jumping" + isJumping);
        }
        else
        {
            isJumping = false;
        }

    }

    private void FixedUpdate()
    {
    //if isJumping and canJump is True then add Force Vector3.up (SPACEBAR EDITION)
        if(isJumping && canJump)
        { 
            rb2d.AddForce(Vector3.up * jumpForce);

        }
    }


    private Vector3 Direction()
    {
        /*This is a Function that will return a Vector3

        Temporary Vector to hold our direction
        Made a Variable called "V" and we Are storing Vector3.Zero aka Directionless
        (0, 0, 0) */
        Vector3 v = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            v += Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            v += Vector3.left;
        }

        //if (Input.GetKey(KeyCode.W))
        //{
        //    v += Vector3.up;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    v += Vector3.down;


        //}
        //Returns our desired Direction after all WASD checks
        return v;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
        //Debug.Log("In Collision Area");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
        //Debug.Log("Out of Collision, Can't Jump");
    }

}




