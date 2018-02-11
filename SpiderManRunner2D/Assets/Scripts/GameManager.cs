using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//This variable stores the text of the score
	public Text scoreText;
	//This variable stores the score points
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
