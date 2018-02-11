using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	Player player = new Player();
	public Rigidbody2D myRigibody2D;
	public KeyCode keyJump = KeyCode.Space;

	public string scene = "level2D";

	void Start () {

			myRigibody2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

		player.PlayerJump(keyJump, myRigibody2D, player.jumpForce);
		
		player.PlayerMoveForward(myRigibody2D, player.moveSpeed);
		
		
	}	

	 void OnTriggerEnter2D(Collider2D collision) {
		
		 if(collision.CompareTag("ItemGood")){
			 Destroy(collision.gameObject);
			 Debug.Log("Punto Positivo!!");

		 }else if(collision.CompareTag("ItemBad")){
			 Destroy(collision.gameObject);
			 Debug.Log("Punto Negativo!!");
		 }else if(collision.CompareTag("DeathZone")){
			 player.PlayerDeath(scene);
		 }else{
			 Debug.Log("Cambio de Apariencia!");
			 Destroy(collision.gameObject);
		 }


	}
}
