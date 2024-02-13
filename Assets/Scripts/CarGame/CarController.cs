using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    // Update is called once per frame
    [SerializeField] private float speed, turnSpeed;
    private Rigidbody body;
    private float steeringInput;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(Input.GetKey("w"))
        {
            body.AddForce(transform.forward * speed*Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey("s"))
        {
            body.AddForce(-transform.forward * speed*Time.deltaTime, ForceMode.Impulse);
        }
        steeringInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, steeringInput * turnSpeed * Time.deltaTime*body.velocity.magnitude);
    }
}
