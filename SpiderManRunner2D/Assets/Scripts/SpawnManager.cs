using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject[] itemPreFabs;

	public float intervalMinTime = 1f;
	public float intervalMaxTime = 2f;

	public float intervalTimeLimit = 1f;

	 void Start() {
		 StartCoroutine(SpawnCoroutine((Random.Range(intervalMinTime,intervalMaxTime))));
	}

	public float DecreasePlatformTime(float time, int proportion){

		if(time > intervalTimeLimit && this.gameObject.CompareTag("PlatformGenerator")){
			return time = time / proportion;
		}else{
			return time;
		}
		
	}

	public float DecreaseItemTime(float time, int proportion){

		if(time > intervalTimeLimit && this.gameObject.CompareTag("ItemGenerator")){
			return time = time / proportion;
		}else{
			return time;
		}
		
	}

	IEnumerator SpawnCoroutine(float waitTime){
		yield return new WaitForSeconds(waitTime);
		Instantiate(itemPreFabs[Random.Range(0, itemPreFabs.Length)], transform.position, Quaternion.identity );
		StartCoroutine(SpawnCoroutine(Random.Range(intervalMinTime, intervalMaxTime)));
	}
}
