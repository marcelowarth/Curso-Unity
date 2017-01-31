using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parent;
	
	void Start() {
		parent = GameObject.Find ("Defenders");
		if(!parent) {
			parent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown() {
		GameObject defender = Button.selectedDefender;
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate(defender, calculatePointOfMouseClick(), zeroRot) as GameObject;
		newDef.transform.parent = parent.transform;
	}
	
	Vector2 calculatePointOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return SnapToGrid(worldPos);
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPosition) {
		Vector2 snapped = new Vector2(Mathf.RoundToInt(rawWorldPosition.x), Mathf.RoundToInt(rawWorldPosition.y));
		return snapped;		
	}
}
