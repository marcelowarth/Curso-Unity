﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	
	private Text text;
	public static int score = 0;
	
	void Start() {
		text = GetComponent<Text>();
		text.text = score.ToString();
		Reset();
	}
	
	public void Score (int points) {
		score += points;
		text.text = score.ToString();
	}
	
	public static void Reset() {
		score = 0;
	}
}
