using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player{

	public float  jumpForce;
	public float moveSpeed;

	public float maxSpeed;
	public string scene;


	public Player(){
		jumpForce = 20f;
		moveSpeed = 7f;
		maxSpeed = 9f;
	}

	public Player(float jumpForce, float moveSpeed){
		this.jumpForce = jumpForce;
		this.moveSpeed = moveSpeed;
	}

    public void PlayerDeath(string scene){
		SceneManager.LoadScene(scene);
	}

	public void PlayerJump(KeyCode key, Rigidbody2D rigidBody2D, float jumpForce){
		if(Input.GetKeyDown(KeyCode.Space)){
			rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
		}
	}

	public void PlayerMoveForward(Rigidbody2D rigidbody2D, float moveSpeed){
		rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
	}

	public void IncreaseSpeed(){
		if(moveSpeed<= maxSpeed){
			this.moveSpeed++;
		}	
	}

	public void BacktoNormalSpeed(){
		this.moveSpeed = 7f;
	}
}
