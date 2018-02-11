using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {

	private string scene = "level2D";

	public void OnTriggerEnter2D(Collider2D collision) {
		Destroy(collision.gameObject);
	}
}
