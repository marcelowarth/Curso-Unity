using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text text;
	private int starsTotal = 0;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		UpdateDisplay();
	}
	
	public void AddStars(int stars) {
		starsTotal += stars;
		UpdateDisplay();
	}
	
	public void UseStars(int stars) {
		starsTotal -= stars;
		UpdateDisplay();
	}
	
	private void UpdateDisplay() {
		text.text = starsTotal.ToString();
	}
}
