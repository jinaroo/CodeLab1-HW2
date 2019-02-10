using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badStarController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<velocityPlayerController>().lives--; //lives go down
        }
        
        Destroy(gameObject);
    }
}
