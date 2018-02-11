using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//These variables allow us to access to Player components
	Player player = new Player();
	public Rigidbody2D myRigibody2D;
	//This variable sets the keyboard of the key to jump
	public KeyCode keyJump = KeyCode.Space;

	//This variable sets the level to load
	public string scene = "level2D";

	//This variable allow us to access to GameManager components
	private GameManager gameManager;
	//This variable allow us to access to Spawn Manager components
	private SpawnManager[] spawnManager;
	//These variables stores Spawn Manager max and min values of time
	private float[] intervalMaxValues;
	private float[] intervalMinValues;
	
	//These variables sets Sprites
	public Sprite superiorSpiderman;
	public Sprite basicSpiderman;


	void Start () {

		myRigibody2D = GetComponent<Rigidbody2D>();
		gameManager = FindObjectOfType<GameManager>();
		spawnManager = FindObjectsOfType<SpawnManager>();
		intervalMaxValues =  new float[spawnManager.Length];
		intervalMinValues =  new float[spawnManager.Length];
		FillTimeValues(spawnManager, intervalMaxValues, intervalMinValues);

	}
	
	void Update () {

		player.PlayerJump(keyJump, myRigibody2D, player.jumpForce);
		
		player.PlayerMoveForward(myRigibody2D, player.moveSpeed);
		
		
	}	

	 void OnTriggerEnter2D(Collider2D collision) {
		
		 if(collision.CompareTag("ItemGood")){
			 Destroy(collision.gameObject);
			 gameManager.AddScore(player);
		 }else if(collision.CompareTag("ItemBad")){
			 Destroy(collision.gameObject);
			 gameManager.MinusScore(player);
		 }else if(collision.CompareTag("DeathZone")){
			 player.PlayerDeath(scene);
		 }else{
			 Destroy(collision.gameObject);
			 player.roleChanged = true;
			 DecreaseSpawnGeneratorsTimes(spawnManager);
			 player.IncreaseSpeed();
			 StartCoroutine(BackToRegularStats(player));
			 changeSpriteAvatar(superiorSpiderman);

		 }


	}

	//This method sets back player's speed, sprite, role and return Spawn Manager to Original values
	public IEnumerator BackToRegularStats(Player player){
		 	yield return new WaitForSeconds(25);
		    player.BacktoNormalSpeed();
			BackToTimeOriginalValues(spawnManager, intervalMaxValues, intervalMinValues);
			changeSpriteAvatar(basicSpiderman);
			player.roleChanged = false;

	}

	/*This method decreases the max and min values from Spawn Manager, keeping the speed of the game 
	  proportional to generate platforms and items when the player goes faster
	*/ 
	public void DecreaseSpawnGeneratorsTimes(SpawnManager[] spawnManager){
		for(int i =0; i<spawnManager.Length; i++){
			spawnManager[i].intervalMinTime=spawnManager[i].DecreasePlatformTime(spawnManager[i].intervalMinTime, 2);
			 spawnManager[i].intervalMaxTime=spawnManager[i].DecreasePlatformTime(spawnManager[i].intervalMaxTime, 2);
			 spawnManager[i].intervalMinTime=spawnManager[i].DecreaseItemTime(spawnManager[i].intervalMinTime, 2);
			 spawnManager[i].intervalMaxTime=spawnManager[i].DecreaseItemTime(spawnManager[i].intervalMaxTime, 2);
			 }
	}

	//This method fills arrays to store max and min time values from spawn manager
	public void FillTimeValues(SpawnManager[] spawnManager, float[] intervalMaxValues, float[] intervalMinValues){
		for(int i = 0; i<spawnManager.Length; i++ ){
			intervalMaxValues[i] = spawnManager[i].intervalMaxTime;
			intervalMinValues[i] = spawnManager[i].intervalMinTime;
		}
	}
	//This method put the original values of max and min time of spawn manager
	public void BackToTimeOriginalValues(SpawnManager[] spawnManager, float[] intervalMaxValues, float[] intervalMinValues){
		for(int i = 0; i<spawnManager.Length; i++ ){
			spawnManager[i].intervalMaxTime = intervalMaxValues[i];
			spawnManager[i].intervalMinTime = intervalMinValues[i];
		}
	}

	//This methos changes the sprite of the player
	public void changeSpriteAvatar(Sprite spiderman){
		this.GetComponent<SpriteRenderer>().sprite = spiderman;
	}

}
