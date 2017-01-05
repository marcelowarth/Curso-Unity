using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int max, min, guess;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame () {
		ResetVariables();
		print("========================");
		print("Welcome to Number Wizard");
		print("Pick a number in you head and dont tell me.");
		print("The highest number you can pick is " + max + ".");
		max = max + 1;
		print("The lowest number you can pick is " + min + ".");
		GuessMessage();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			NextGuess();
		} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			NextGuess();
		} else if(Input.GetKeyDown(KeyCode.Return)) {
			print("I won!");
			StartGame();
		}
	}
	
	void ResetVariables () {
		max = 1000;
		min = 1;
		guess = 500;
	}
	
	void NextGuess () {
		guess = (max + min) / 2;
		GuessMessage();
	}
	
	void GuessMessage () {
		print("Higher or lower than" + guess + "?");
		print("Up arrow = higher, down arrow = lower, return = equal.");
	}
}
