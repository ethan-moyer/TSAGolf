using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class golfBall : MonoBehaviour {
	public int rotateSpeed = 100;
	public float launchSpeed = 20;
	private float power;
	public GameObject uiArrow;
	private Rigidbody rb;
	private GameObject strokeObject;
	public int currentStroke;
	public Text strokeText;
	public Text powerText;
	public GameObject black;
	public Vector3 startLocation;
	// Use this for initialization
	void Start () {
		Debug.Log ("Running");
		strokeObject = GameObject.Find ("Variables");
		rb = GetComponent<Rigidbody>();
		startLocation.x = gameObject.transform.position.x;
		startLocation.y = gameObject.transform.position.y;
		startLocation.z = gameObject.transform.position.z;
		currentStroke = strokeObject.GetComponent<currentStroke> ().stroke;
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.y == 0) {
			uiArrow.SetActive (true);
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (Vector3.back * Time.deltaTime * rotateSpeed);
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				rb.AddRelativeForce(Vector3.up * launchSpeed);
				currentStroke += 1;
			}
			if (Input.GetKey (KeyCode.UpArrow) && launchSpeed <= 5600) {
				launchSpeed += 20;
				uiArrow.transform.localScale += new Vector3(0f, 0.002f, 0f);
			}	
			if (Input.GetKey (KeyCode.DownArrow) && launchSpeed > 0) {
				launchSpeed -= 20;
				uiArrow.transform.localScale -= new Vector3(0f, 0.002f, 0f);
			}
		} else {
			uiArrow.SetActive (false);
		}
		strokeText.text = "Current Stroke: " + currentStroke;
		power = Mathf.Round(((launchSpeed/5620)*100) * 10f) / 10f;
		powerText.text = "Power: " + power + "%";
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "HalfSandTrap" || col.gameObject.name == "SandTrap")
			rb.drag = 7;
		if (col.gameObject.name == "water") {
			black.GetComponent <SpriteRenderer> ().color += new Color (0, 0, 0, 255f);
			gameObject.transform.position = startLocation;
			rb.velocity = new Vector3(0f, 0f, 0f);
			StartCoroutine (FadeBack (true));
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.name == "HalfSandTrap" || col.gameObject.name == "SandTrap")
			rb.drag = 3;
	}
	IEnumerator FadeBack(bool FadeAway) {
		for (float i = 1; i >= 0; i -= Time.deltaTime) {
			Debug.Log (i);
			black.GetComponent <SpriteRenderer> ().color = new Color (0, 0, 0, i);
			yield return null;
		}
	}
}
