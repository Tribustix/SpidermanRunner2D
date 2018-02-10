using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player{

	public float  jumpForce;
	public float speed;
	public string secene;


	public Player(){
		jumpForce = 20f;
		speed = 5f;
	}

	public Player(float jumpForce, float speed){
		this.jumpForce = jumpForce;
		this.speed = speed;
	}

	void playerDeath(string scene){
		SceneManager.LoadScene(scene);
	}
}
