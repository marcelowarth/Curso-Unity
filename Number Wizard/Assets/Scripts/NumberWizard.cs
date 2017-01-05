using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int max = 1000, min = 0;
		
		print("Welcome to Number Wizard");
		print("Pick a number in you head and dont tell me.");
		print("The highest number you can pick is " + max + ".");
		print("The lowest number you can pick is " + min + ".");
		print("Is the number higher or lower than 500?");
		print("Up arrow = higher, down arrow = lower, return = equal.");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			print("Up arrow pressed.");
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)) {
			print("Down arrow pressed.");
		}
		if(Input.GetKeyDown(KeyCode.Return)) {
			print("Return pressed.");
		}
	}
}
