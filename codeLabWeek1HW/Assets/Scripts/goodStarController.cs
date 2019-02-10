using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodStarController : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			other.gameObject.GetComponent<velocityPlayerController>().score++; //score goes up
		}
		
		Destroy(gameObject);
	}
}
