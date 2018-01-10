using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScreen : MonoBehaviour {
	public GameObject variables;
	public Text congrats;
	public Text score;
	private int difference;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		variables = GameObject.Find ("Variables");
		if (variables.GetComponent<currentStroke> ().totalStroke > 34) {
			congrats.text = "Better luck next time";
			difference = variables.GetComponent<currentStroke> ().totalStroke - 34;
			score.text = "Your score was " + difference + " over par";
		}
		if (variables.GetComponent<currentStroke> ().totalStroke < 34) {
			congrats.text = "Congratulations";
			difference = 34 - variables.GetComponent<currentStroke> ().totalStroke;
			score.text = "Your score was " + difference + " under par";
		}
		if (variables.GetComponent<currentStroke> ().totalStroke == 34) {
			congrats.text = "Congratulations";
			score.text = "Your score was 0 under par";
		}
	}
}
