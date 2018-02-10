using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Player player = new Player();

	public Rigidbody2D myRigibody2D;


		void Start () {

			myRigibody2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){
			myRigibody2D.velocity = new Vector2(myRigibody2D.velocity.x, player.jumpForce);
		}
		
		myRigibody2D.velocity = new Vector2(player.speed, myRigibody2D.velocity.y);
		
	}	
}
