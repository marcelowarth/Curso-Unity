using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {
						cell, mirror, sheets_0, lock_0, 
						cell_mirror, sheets_1, lock_1, 
						corridor_0, closet_0, floor, stairs_0
						};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if(myState == States.cell) {
			cell();
		} else if (myState == States.sheets_0) {
			sheets_0();
		} else if (myState == States.mirror) {
			mirror();
		} else if (myState == States.lock_0) {
			lock_0();
		} else if (myState == States.cell_mirror) {
			cell_mirror();
		} else if (myState == States.lock_1) {
			lock_1();
		} else if (myState == States.sheets_1) {
			sheets_1();
		} else if (myState == States.corridor_0) {
			corridor_0();
		} else if (myState == States.closet_0) {
			closet_0();
		} else if (myState == States.floor) {
			floor();
		} else if (myState == States.stairs_0) {
			stairs_0();
		}
	}
	
	void cell () {
		text.text = "You are in a prison cell, and you want to escape. There are " +
			"some dirty sheets on the bed, a mirror on the wall and the door " +
			"exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor " +
			"is locked from the outside.\n\n" + 
			"Press S to view Sheets, M to view Mirror and L to view Lock";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_0;
		} else if(Input.GetKeyDown(KeyCode.M)){
			myState = States.mirror;
		} else if(Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_0;
		}
	}
	
	void sheets_0 () {
		text.text = "You cant believe you sleep on these things. Surely its " +
			"time somebody change them. The pleasures of prison life " +
			"I guess!\n\n" + 
			"Press R to Return to roaming you cell";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	
	void lock_0 () {
		text.text = "The door is locked, you need something to see the other side!\n\n" + 
				"Press R to Return to roaming you cell";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	
	void mirror () {
		text.text = "The prison life has changed you, you can see that in the mirror.\n\n" + 
			"Press R to Return to roaming you cell or T to Take the mirror";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		} else if(Input.GetKeyDown(KeyCode.T)){
			myState = States.cell_mirror;
		}
	}
	
	void cell_mirror () {
		text.text = "You now have the mirror, you may see the other side of the door!\n\n" + 
				"Press S to view Sheets and L to view Lock";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_1;
		} else if(Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_1;
		}
	}
	
	void sheets_1 () {
		text.text = "You cant believe you sleep on these things. Surely its " +
			"time somebody change them. The pleasures of prison life " +
				"I guess!\n\n" + 
				"Press R to Return to roaming you cell";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
		}
	}
	
	void lock_1 () {
		text.text = "Using the mirror you see that the guard left the key on the door!\n\n" + 
			"Press R to Return to roaming you cell or O to Open the door";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
		} else if(Input.GetKeyDown(KeyCode.O)){
			myState = States.corridor_0;
		}
	}
	
	void corridor_0 () {
		text.text = "You are in the corridor, what should you do next?\n\n" + 
				"Press S to go to the Stairs, C to go to the Closet or F to look at the Floor";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_0;
		} else if(Input.GetKeyDown(KeyCode.C)){
			myState = States.closet_0;
		} else if(Input.GetKeyDown(KeyCode.F)){
			myState = States.floor;
		}
	}
}
