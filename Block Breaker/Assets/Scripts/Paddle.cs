using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f);
		float mousePosInBlocksX = Input.mousePosition.x / Screen.width * 16; //16 numero de blocos que cabem na tela
		paddlePos.x = Mathf.Clamp(mousePosInBlocksX,0.5f,15.5f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f);
		float ballPos = ball.transform.position.x;
		paddlePos.x = Mathf.Clamp(ballPos,0.5f,15.5f);
		this.transform.position = paddlePos;
	}
}
