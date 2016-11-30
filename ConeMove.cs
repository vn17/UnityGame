//USEFUL
using UnityEngine;
using System.Collections;

public class ConeMove : MonoBehaviour {
	void Start(){
		transform.position += new Vector3 (Random.Range (-1.4f, 1.4f), 0, 0);
	}
	void FixedUpdate () {
		if (transform.position.y <= -1.8f)
			transform.position = new Vector3 (Random.Range (-1.4f, 1.4f), 18.2f, 0);
		transform.position+=Vector3.down * Roadmove.scrollSpeed / 100f;
	}
}
