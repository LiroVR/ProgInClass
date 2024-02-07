using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballrolling : MonoBehaviour
{
    [SerializeField] private float rollingForce;
    private Vector3 ballToTarget;
    private Rigidbody objectRB;
    // Start is called before the first frame update
    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a"))
        {

            ballToTarget = ((transform.position + new Vector3(1f,0f,0f)) - transform.position).normalized;
            objectRB.AddForce(ballToTarget*rollingForce*Time.deltaTime);
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
        
    }
}
