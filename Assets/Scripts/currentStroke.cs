using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentStroke : MonoBehaviour {
	public int stroke = 0;
	public int totalStroke = 0;
	public GameObject audioObject;
	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
		DontDestroyOnLoad (audioObject);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
