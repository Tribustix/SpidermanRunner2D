using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Player player = new Player();
	public Rigidbody2D myRigibody2D;
	public KeyCode keyJump = KeyCode.Space;


		void Start () {

			myRigibody2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

		player.PlayerJump(keyJump, myRigibody2D, player.jumpForce);
		
		player.PlayerMoveForward(myRigibody2D, player.moveSpeed);
		
		
	}	
}
