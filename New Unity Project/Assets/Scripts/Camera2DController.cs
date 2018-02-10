﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DController : MonoBehaviour {

	public Transform targetPlayer;
	private	float positionX = 4f;
	private float positionY = 0f;
	private float positionZ = -10f;

	// Use this for initialization
	void Start () {

		if(targetPlayer == null){
			targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(targetPlayer.position.x + positionX, positionY, positionZ);
	}

}
