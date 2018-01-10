using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
	public GameObject player;
	private float playerX;
	private float playerY;
	public bool showMap = true;
	public Camera playerCam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M))
			showMap = !showMap;
		if (showMap == true) {
			//playerX = 0f;
			//playerY = 34.4f;
			playerCam.orthographicSize = 50.85f;
			//gameObject.transform.position = new Vector3 (playerX, playerY, -2f);
			playerX = player.transform.position.x;
			playerY = player.transform.position.y;
			gameObject.transform.position = new Vector3 (playerX, playerY, -2f);
		}
		if (showMap == false) {
			playerCam.orthographicSize = 24.48661f;
			playerX = player.transform.position.x;
			playerY = player.transform.position.y;
			gameObject.transform.position = new Vector3 (playerX, playerY, -2f);
		}
	}
}
