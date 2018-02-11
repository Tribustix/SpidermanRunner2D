using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerController : MonoBehaviour {

	public GameObject[] itemPreFabs;

	public float minTime = 1f;
	public float maxTime = 2f;

	 void Start() {
		 StartCoroutine(SpawnCoroutine((Random.Range(minTime, maxTime))));
	}

	IEnumerator SpawnCoroutine(float waitTime){
		yield return new WaitForSeconds(waitTime);
		Instantiate(itemPreFabs[Random.Range(0, itemPreFabs.Length)], transform.position, Quaternion.identity );
		StartCoroutine(SpawnCoroutine(Random.Range(minTime, maxTime)));
	}
}
