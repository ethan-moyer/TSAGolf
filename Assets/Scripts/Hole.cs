using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour {
	public GameObject hole;
	public Text endText;
	public int par;
	public int currentStroke;
	public AudioSource goodScore;
	public AudioSource badScore;
	private GameObject strokeObject;
	private bool levelComplete = false;
	public GameObject pSprite;
	private SpriteRenderer pRender;
	public GameObject aSprite;
	private SpriteRenderer aRender;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		strokeObject = GameObject.Find ("Variables");
		levelComplete = false;
		pRender = pSprite.GetComponent<SpriteRenderer> ();
		aRender = aSprite.GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody> ();
		Debug.Log (strokeObject.GetComponent<currentStroke> ().totalStroke);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return) && levelComplete == true) {
			Debug.Log ("Key Pressed");
			strokeObject.GetComponent<currentStroke> ().stroke = 0;
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		if (Input.GetKey (KeyCode.F))
			Application.LoadLevel (Application.loadedLevel + 1);
	}
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "HolePhysics") {
			pRender.enabled = false;
			aRender.enabled = false;
			rb.velocity = new Vector3 (0f, 0f, 0f);
			Debug.Log("Collided");
			currentStroke = gameObject.GetComponent<golfBall>().currentStroke;
			strokeObject.GetComponent<currentStroke> ().stroke = currentStroke;
			strokeObject.GetComponent<currentStroke> ().totalStroke += currentStroke;
				levelComplete = true;
				if (strokeObject.GetComponent<currentStroke> ().stroke == par - 1)
					endText.text = "Birdie\nPress Enter To Continue";
				if (strokeObject.GetComponent<currentStroke> ().stroke == par - 2)
					endText.text = "Eagle\nPress Enter To Continue";
				if (strokeObject.GetComponent<currentStroke> ().stroke == par)
					endText.text = "Par\nPress Enter To Continue";
				if (strokeObject.GetComponent<currentStroke> ().stroke == par + 1)
					endText.text = "Bogey\nPress Enter To Continue";
				if (strokeObject.GetComponent<currentStroke> ().stroke == par + 2)
					endText.text = "Double Bogey\nPress Enter To Continue";
				if (strokeObject.GetComponent<currentStroke> ().stroke == par + 3)
					endText.text = "Triple Bogey\nPress Enter To Continue";
				if (strokeObject.GetComponent<currentStroke> ().stroke > par + 3)
					endText.text = "Over Par\nPress Enter To Continue";
				if (strokeObject.GetComponent<currentStroke> ().stroke < par - 2)
					endText.text = "Under Par\nPress Enter To Continue";
				if (strokeObject.GetComponent<currentStroke> ().stroke > par)
					badScore.Play ();
				if (strokeObject.GetComponent<currentStroke> ().stroke <= par)
					goodScore.Play ();
		}
	}
}
