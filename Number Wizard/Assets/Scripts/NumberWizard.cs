using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int max = 1000, min = 1, guess = 500;
	
	// Use this for initialization
	void Start () {
		max = max + 1;
		print("Welcome to Number Wizard");
		print("Pick a number in you head and dont tell me.");
		print("The highest number you can pick is " + max + ".");
		print("The lowest number you can pick is " + min + ".");
		print("Is the number higher or lower than " + guess + "?");
		print("Up arrow = higher, down arrow = lower, return = equal.");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			guess = (max + min) / 2;
			print("Higher or lower than" + guess + "?");
		} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			guess = (max + min) / 2;
			print("Higher or lower than" + guess + "?");
		} else if(Input.GetKeyDown(KeyCode.Return)) {
			print("I won!");
		}
	}
}
