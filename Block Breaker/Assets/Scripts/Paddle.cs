using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f);
		
		float mousePosInBlocksX = Input.mousePosition.x / Screen.width * 16; //16 numero de blocos que cabem na tela
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocksX,0.5f,15.5f);
		
		//this.transform.position.Set(mousePosInBlocksX,0,0); 
		this.transform.position = paddlePos;
	}
}
