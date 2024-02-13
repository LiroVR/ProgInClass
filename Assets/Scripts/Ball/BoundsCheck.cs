using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [SerializeField] private Timer timer;

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            timer.gameActive = false;
        }
    }
}
