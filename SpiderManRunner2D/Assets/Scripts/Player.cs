using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player{

	// Variable to set the jump force of the player
	public float  jumpForce;
	// Variable to set the speed of movement of the player
	public float moveSpeed;

	// Variable to set the max speed that the player can reach
	public float maxSpeed;
	// Variable to set the scene that we want to load
	public string scene;

	//Constructors
	public Player(){
		jumpForce = 20f;
		moveSpeed = 6f;
		maxSpeed = 9f;
	}

	public Player(float jumpForce, float moveSpeed){
		this.jumpForce = jumpForce;
		this.moveSpeed = moveSpeed;
	}

	//This method loads a scene when the player dies
    public void PlayerDeath(string scene){
		SceneManager.LoadScene(scene);
	}

	//This method makes that the player jump
	public void PlayerJump(KeyCode key, Rigidbody2D rigidBody2D, float jumpForce){
		if(Input.GetKeyDown(KeyCode.Space)){
			rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
		}
	}

	//This method makes that the player move automatically to the left
	public void PlayerMoveForward(Rigidbody2D rigidbody2D, float moveSpeed){
		rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
	}

	//This method increase player's speed
	public void IncreaseSpeed(){
		if(moveSpeed<= maxSpeed){
			this.moveSpeed++;
		}	
	}

	//This method set player's speed back to its original value
	public void BacktoNormalSpeed(){
		this.moveSpeed = 6f;
	}
}
