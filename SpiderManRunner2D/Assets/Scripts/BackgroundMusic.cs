using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

	//Variable to set the audio from audiosource
	public AudioSource myAudioSource;

	//Variable to set the Game Object to not destroy the song when loadin automatically
	public static GameObject backgroundMusicObject;

	/*This method destroys any music background to
	  not generate duplicates
	*/
	void Awake(){
		if(backgroundMusicObject){
			Destroy(gameObject);
			return;
		}
		myAudioSource.Play();
		backgroundMusicObject = gameObject;
	}
}
