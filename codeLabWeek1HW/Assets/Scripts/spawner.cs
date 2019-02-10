using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnGoodStar", 1, 5); //call spawn after 1 seconds and then every 3 seconds
		InvokeRepeating("SpawnBadStar", 2, 5);
	}

	void SpawnGoodStar()
	{
		GameObject newGoodStar = Instantiate(Resources.Load<GameObject>("Prefabs/goodStar"));
		newGoodStar.transform.position = new Vector2(Random.Range(-3,3),Random.Range(-6,10));
		newGoodStar.transform.Rotate(0, 0, Random.Range(0,360));
	}

	void SpawnBadStar()
	{
		GameObject newBadStar = Instantiate(Resources.Load<GameObject>("Prefabs/badStar"));
		newBadStar.transform.position = new Vector2(Random.Range(-3,3),Random.Range(-6,10));
		newBadStar.transform.Rotate(0, 0, Random.Range(0,360));
	}
}
