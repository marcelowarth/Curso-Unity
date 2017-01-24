using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	
	private AudioSource music;
	
	void Awake() {
		if(instance != null && instance != this) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			PlayMusic(startClip);
		}
	}
	
	void OnLevelWasLoaded(int level) {
		if (music == null) {            
			music = GetComponent<AudioSource>();      
		} else  {           
			music.Stop(); 
		} 
		
		if(level == 0) {
			PlayMusic(startClip);
		} else if (level == 1) {
			PlayMusic(gameClip);
		} else if (level == 2) {
			PlayMusic(endClip);
		}
	}
	
	void PlayMusic(AudioClip clip) {
		music.clip = clip;
		music.loop = true;
		music.Play();
	}
}
