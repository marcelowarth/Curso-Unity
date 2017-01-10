using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int max, min, guess, maxGuessesAllowed = 5;
	public Text text;
	
	void Start () {
		StartGame();
	}
	
	void StartGame () {
		ResetVariables();
		max = max + 1;
	}
		
	public void GuessHigher() {
		min = guess;
		NextGuess();
	}
	
	public void GuessLower() {
		max = guess;
		NextGuess();
	}
		
	void ResetVariables () {
		max = 1000;
		min = 1;
		guess = 500;
	}
	
	void NextGuess () {
		guess = (max + min) / 2;
		text.text = guess.ToString();
		maxGuessesAllowed = maxGuessesAllowed - 1;
		if (maxGuessesAllowed <= 0) {
			Application.LoadLevel("Win");
		}
	}
	
}
