using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public float speed;
    int Result;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(speed,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed,0,0);
    }

    int addition(int a, int b)
    {
        Result = a + b;
        return Result;
    }
}
