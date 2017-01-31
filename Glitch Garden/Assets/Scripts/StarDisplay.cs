using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text text;
	private int starsTotal = 200;
	
	public enum Status {SUCCESS, FAILURE}
	
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		UpdateDisplay();
	}
	
	public void AddStars(int stars) {
		starsTotal += stars;
		UpdateDisplay();
	}
	
	public Status UseStars(int stars) {
		if(starsTotal >= stars) {
			starsTotal -= stars;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay() {
		text.text = starsTotal.ToString();
	}
}
