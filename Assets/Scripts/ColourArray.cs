using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourArray : MonoBehaviour
{
    public GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
