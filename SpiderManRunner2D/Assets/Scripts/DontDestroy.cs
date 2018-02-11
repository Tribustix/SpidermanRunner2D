using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	//Method to not destroy an object automatically when loading a new scene
	private void Awake(){
		DontDestroyOnLoad(gameObject);
	}
}
