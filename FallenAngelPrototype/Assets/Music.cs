using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

public AudioClip[] clips;
AudioSource source;

	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	void Update () {
		source.volume = Mathf.Lerp(source.volume,1,Time.unscaledDeltaTime / 5);
	}

	public void ChangeMusic(int newClip,bool fadeIn){
		source.Stop();
		source.clip = clips[newClip];
		source.Play();
		if(fadeIn == true){
			source.volume = 0;
			source.time = Random.Range(0,clips[newClip].length);
		}
	}
}
