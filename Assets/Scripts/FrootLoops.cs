using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrootLoops : MonoBehaviour
{
    void Start()
    {
        int x = 1;
        int y = 0;
        while(x<=10)
        {
            y+=x;
            x++;
        }
        Debug.Log(y);
    }
}
