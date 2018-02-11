using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	Player player = new Player();
	public Rigidbody2D myRigibody2D;
	public KeyCode keyJump = KeyCode.Space;

	public string scene = "level2D";

	private GameManager gameManager;
	private SpawnManager[] spawnManager;
	private float[] intervalMaxValues;
	private float[] intervalMinValues;
	
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
			 gameManager.AddScore();
		 }else if(collision.CompareTag("ItemBad")){
			 Destroy(collision.gameObject);
			 gameManager.MinusScore();
		 }else if(collision.CompareTag("DeathZone")){
			 player.PlayerDeath(scene);
		 }else{
			 Destroy(collision.gameObject);
			 DecreaseSpawnGeneratorsTimes(spawnManager);
			 player.IncreaseSpeed();
			 StartCoroutine(BackToRegularStats(player));
			 changeSpriteAvatar(superiorSpiderman);

		 }


	}

	public IEnumerator BackToRegularStats(Player player){
		 	yield return new WaitForSeconds(15);
		    player.BacktoNormalSpeed();
			BackToTimeOriginalValues(spawnManager, intervalMaxValues, intervalMinValues);
			changeSpriteAvatar(basicSpiderman);
	}

	public void DecreaseSpawnGeneratorsTimes(SpawnManager[] spawnManager){
		for(int i =0; i<spawnManager.Length; i++){
			spawnManager[i].intervalMinTime=spawnManager[i].DecreasePlatformTime(spawnManager[i].intervalMinTime, 2);
			 spawnManager[i].intervalMaxTime=spawnManager[i].DecreasePlatformTime(spawnManager[i].intervalMaxTime, 2);
			 spawnManager[i].intervalMinTime=spawnManager[i].DecreaseItemTime(spawnManager[i].intervalMinTime, 2);
			 spawnManager[i].intervalMaxTime=spawnManager[i].DecreaseItemTime(spawnManager[i].intervalMaxTime, 2);
			 }
	}

	public void FillTimeValues(SpawnManager[] spawnManager, float[] intervalMaxValues, float[] intervalMinValues){
		for(int i = 0; i<spawnManager.Length; i++ ){
			intervalMaxValues[i] = spawnManager[i].intervalMaxTime;
			intervalMinValues[i] = spawnManager[i].intervalMinTime;
		}
	}

	public void BackToTimeOriginalValues(SpawnManager[] spawnManager, float[] intervalMaxValues, float[] intervalMinValues){
		for(int i = 0; i<spawnManager.Length; i++ ){
			spawnManager[i].intervalMaxTime = intervalMaxValues[i];
			spawnManager[i].intervalMinTime = intervalMinValues[i];
		}
	}

	public void changeSpriteAvatar(Sprite spiderman){
		this.GetComponent<SpriteRenderer>().sprite = spiderman;
	}

}
