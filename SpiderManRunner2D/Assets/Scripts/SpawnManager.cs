using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	//This variable stores all the items from Prefabs folder
	public GameObject[] itemPreFabs;
	
	public float intervalMinTime = 1f;
	public float intervalMaxTime = 2f;

	//The min value that the interval time max or min should value
	public float intervalTimeLimit = 1f;

	 void Start() {
		 StartCoroutine(SpawnCoroutine((Random.Range(intervalMinTime,intervalMaxTime))));
	}

	//This method decrease the time (max or min) from the Platform Generator Object
	public float DecreasePlatformTime(float time, int proportion){

		if(time > intervalTimeLimit && this.gameObject.CompareTag("PlatformGenerator")){
			return time = time / proportion;
		}else{
			return time;
		}
		
	}

	//This method decrease the time (max or min) from the Item Generator Object
	public float DecreaseItemTime(float time, int proportion){

		if(time > intervalTimeLimit && this.gameObject.CompareTag("ItemGenerator")){
			return time = time / proportion;
		}else{
			return time;
		}
		
	}

	//This iterator delay and intance objects from Prefab folder and starts a coroutine to generate objects with a time interval
	IEnumerator SpawnCoroutine(float waitTime){
		yield return new WaitForSeconds(waitTime);
		Instantiate(itemPreFabs[Random.Range(0, itemPreFabs.Length)], transform.position, Quaternion.identity );
		StartCoroutine(SpawnCoroutine(Random.Range(intervalMinTime, intervalMaxTime)));
	}
}
