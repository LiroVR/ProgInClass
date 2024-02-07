using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public GameObject block, blankObject;
    public int width = 10;
    public int height = 4;
    public int numberOfObjects = 20;
    //public float radius = 5f;
    private float xOffset = 0, yOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Quaternion rot = Quaternion.Euler(0, (angle * Mathf.Rad2Deg)-90, 0);
            var tempObject = Instantiate(blankObject, new Vector3(xOffset,0,yOffset), rot);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var spawnedObject = Instantiate(block, tempObject.transform);
                    spawnedObject.transform.localPosition = new Vector3(x, y, 0);
                }
            }
            xOffset += (Mathf.Sin(angle) * width);
            yOffset += (Mathf.Cos(angle) * width);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
