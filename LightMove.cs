//USEFUL
using UnityEngine;
using System.Collections;

public class LightMove : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y <= 0)
			transform.position = new Vector3 (0, 30, -1);
		transform.position+=Vector3.down * Roadmove.scrollSpeed / 100f;
	}
}