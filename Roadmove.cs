//USEFUL
using UnityEngine;
using System.Collections;

public class Roadmove : MonoBehaviour
{
	public static float scrollSpeed;
	public float tileSizeZ,tm;
//	public Transform road;
	public GameObject roads;
//	public Rigidbody road1,road2;
//		,fences,movingCars,suvs,trucks;
	bool cloned = false;
	static bool p=false;
	static int num;
	GameObject hurdles;
	void Start(){
		tm = Time.time;
	}
	void FixedUpdate (){

		if (PlayerController.col) {
			//			Roadmove.scrollSpeed= Mathf.MoveTowardsAngle (Roadmove.scrollSpeed,0,0.01f);
			scrollSpeed *= Mathf.Exp (-0.05f);
		}
		else scrollSpeed = 2+Mathf.Cos (PlayerController.angle) * Mathf.Log (1 + (Time.time-tm)/12)*300*Time.deltaTime;
//		road1.AddForce (Vector3.down*10);
//		road2.AddForce (Vector3.down*10);
//		Debug.Log (scrollSpeed);
//		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
//		transform.position = startPosition + Vector3.down * newPosition;
		transform.position += Vector3.down * scrollSpeed / 100f; 	


//		if (transform.position.y <= -tileSizeZ) {
//				if (transform.position.y <= -tileSizeZ) {
//		if (transform.position.y <= 0 && !cloned) {
//			//			transform.position = Vector3.zero;
//			Instantiate (roads, new Vector3 (0, 5, 0), Quaternion.Euler (0, 0, 0)).name="Road";
//			cloned = true;



			if (transform.position.y <= -7 && !cloned) {
				//			transform.position = Vector3.zero;
				//Instantiate (roads, new Vector3 (0, 10, 0.2f), Quaternion.Euler (0, 0, 0)).name="Terrain-Road";
				cloned = true;
				Ins ();
//			transform.FindChild("kone").transform.position+=
//			for(int i=0;i<transform.childCount;i++)
//				transform.GetChild(i).gameObject.transform.position+=Vector3.right;
			}
		if (transform.position.y <= -5)
			transform.position = new Vector3 (0, 10, 0); 
		}

	void Ins(){
//		if(p%(3*interval)==interval){
//			hurdles=cows;
//		}
//		if(p%(3*interval)==2*interval){
//			hurdles=fences;
//		}
//		if(p%(3*interval)==0){
//			hurdles=cones[p/(3*interval)-1];
//			
//		}
//		if(p>=9*interval){
//			p=1;
//			hurdles=jeep;
//		}
		if (num < 0)
			num++;
		if (p&&num>=0) {
			num=(int)Random.Range (0,7.5f);
//			GameObject ga = (GameObject)Instantiate (hurdle[num], new Vector3(0,5,0), Quaternion.Euler (0, 0, 0));
//			ga.transform.SetParent (this.transform);
//			ga.name = "hurdle";
			if(num==7)num=-3;
		}
		p=!p;
	

			//		GameObject ga = (GameObject)Instantiate (cones);

//			ga.transform.GetChild(0)

		
	}
}