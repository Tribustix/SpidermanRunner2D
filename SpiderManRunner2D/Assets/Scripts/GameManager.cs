using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text scoreText;
	public int playerScore;
	public void AddScore(){

		playerScore++;
		scoreText.text = playerScore.ToString();
	}

	public void MinusScore(){

		if(playerScore>0){
		playerScore--;
		}
		scoreText.text = playerScore.ToString();
	}

}
