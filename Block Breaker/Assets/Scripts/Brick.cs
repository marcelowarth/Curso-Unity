﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public static int breakableCount = 0;
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits() {
		int maxHits = hitSprites.Length + 1;
		timesHit++;
		if(timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	// TODO remove method when we can win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
