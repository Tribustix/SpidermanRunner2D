using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//This variable stores the text of the score
	public Text scoreText;
	//This variable stores the score points
	public int playerScore;
	public void AddScore(Player player){
		if(CheckRoleChanged(player) && playerScore>0){
			playerScore--;
		}else{
		playerScore++;
		}
		
		scoreText.text = playerScore.ToString();
	}

	public void MinusScore(Player player){
		if(CheckRoleChanged(player)){
			playerScore++;
		}else{
		 if(playerScore>0){
			playerScore--;
			}
		}
		
		scoreText.text = playerScore.ToString();
	}

	public bool CheckRoleChanged(Player player){
		if(player.roleChanged){
			return true;
		}
		return false;
	}

}
