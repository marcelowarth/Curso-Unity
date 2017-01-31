using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	private Button[] buttonArray;
	private Text costText;
	
	public static GameObject selectedDefender;	
	public GameObject defenderPrefab;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		if(!costText) {
			Debug.LogWarning(name + " Cost Text not found");
		}
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		foreach(Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
	
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
