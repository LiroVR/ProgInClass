using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//int carrots;
public class ExampleScript : MonoBehaviour
{
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        //Remember, no Russian
        //Debug.Log("My first script")
        //print("Cats are so snuggly, but they scratch when annoyed");
    }

    // Update is called once per frame
    //double carrots = 2;
    void Update()
    {
        //public int carrots;
        //carrots += 2;
        //carrots = Math.Pow(carrots,2);
        //Debug.Log("Carrots = ");
        //Debug.Log(carrots);
        print(name);
    }

    private void OnEnable()
    {
        print("You found me!");
    }

    private void OnDisable()
    {
        print("Gone again!");
    }
}
