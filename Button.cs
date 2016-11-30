//USEFUL
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Button : MonoBehaviour {
	public GameObject button1, button2,scoreMiddle;
	public Font f;
	int i;
	// Use this for initialization
	void Start () {
		button1.SetActive (true);
		button1.GetComponentInChildren<Text>().text = "Play";
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Time.time > 0) {
			button1.GetComponentInChildren<Text> ().text = "Resume";
			button2.SetActive(true);
		}
		if (PlayerController.col)
			button1.SetActive (false);
//		button1.GetComponentInChildren<Text> ().fontSize = 30;
//		button1.GetComponentInChildren<Text> ().font = f;
////		button1.

	}
}
