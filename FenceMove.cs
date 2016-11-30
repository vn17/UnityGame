using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//USEFUL
public class FenceMove : MonoBehaviour {
	int lastDeactiveFence;
	public static int score;
	public Text scorer,highScore;
	bool deact,scored;
	float tm;
	void Start(){
		lastDeactiveFence = (int)Random.Range (0.5f, 2.5f);
		transform.GetChild(lastDeactiveFence).gameObject.SetActive(false);	
		score = 0;
		highScore.text="High Score: "+PlayerPrefs.GetInt("highscore", 0).ToString();
	}
	void FixedUpdate(){
		if (transform.position.y <= -1&&!scored) {
			score++;
			scored=true;
		}
		if (transform.position.y <= -1.8f) {
			transform.position = new Vector3 (0, 18.2f, 0);
			deact = true;
			scored=false;
		}
		transform.position += Vector3.down * Roadmove.scrollSpeed / 100f;
	}
		void Update(){
		scorer.text = score.ToString ();
//		Debug.Log (score);
		if (deact) {
			transform.GetChild (lastDeactiveFence).gameObject.SetActive (true);
			lastDeactiveFence = (int)Random.Range (0.5f, 2.5f);
			transform.GetChild (lastDeactiveFence).gameObject.SetActive (false);
//			Debug.Log (transform.childCount);
			deact = false;
		}
	}

}
	