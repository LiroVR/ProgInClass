using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to control the ball's movement and jumping
public class Ballrolling : MonoBehaviour
{
    [SerializeField] private float rollingForce, jumpForce;
    private Vector3 ballToTarget;
    private Rigidbody objectRB;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a")) //If the player presses the "a" key, the ball moves to the left
        {

            ballToTarget = ((transform.position + new Vector3(1f,0f,0f)) - transform.position).normalized; //Sets the direction the ball should move in, relative to the ball's position in world space
            objectRB.AddForce(ballToTarget*rollingForce*Time.deltaTime); //Applies a force to the ball in the direction it should move
        }
        if(Input.GetKey("d"))
        {
            ballToTarget = ((transform.position + new Vector3(-1f,0f,0f)) - transform.position).normalized;
            objectRB.AddForce(ballToTarget*rollingForce*Time.deltaTime);
        }
        if(Input.GetKey("w")) 
        {
            ballToTarget = ((transform.position + new Vector3(0f,0f,-1f)) - transform.position).normalized;
            objectRB.AddForce(ballToTarget*rollingForce*Time.deltaTime);
        }
        if(Input.GetKey("s"))
        {
            ballToTarget = ((transform.position + new Vector3(0f,0f,1f)) - transform.position).normalized;
            objectRB.AddForce(ballToTarget*rollingForce*Time.deltaTime);
        }
        if(Input.GetKey("space") && isGrounded) //If the player presses the space key and the ball is on the ground, the ball jumps
        {
            ballToTarget = ((transform.position + new Vector3(0f,1f,0f)) - transform.position).normalized;
            objectRB.AddForce(ballToTarget*jumpForce, ForceMode.Impulse); //Applies an impulse force to the ball in the upward direction
            isGrounded = false; //The ball is no longer on the ground, so this gets set to false
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true; //If the ball collides with the ground, the bool gets reset, so it can jump again
        }
    }
}
