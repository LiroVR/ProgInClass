using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeArray : MonoBehaviour
{
    //public int[] score = new int[5];
    //public string[] stringArray = new string[4];
    public GameObject[] objects;
    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        objects[0].GetComponent<Renderer>().material.color = colors[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
