//USEFUL
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	// Use this for initialization
	public static bool col=false,res=false;
	bool tilt,played=false;
	public Transform steering,bar,cam; 
	private Vector3 pos;
	public Text highScore,scoreMiddle;
	Vector3 hPos;
	public GameObject panel,settingsPanel,pause,slider,steeringWheel;
	public static float angle,sens;
	private float hvLast,lastTime,vibrate=1,volume;
	public Slider s,vol;
	public Toggle sliderToggle,tiltToggle,steeringWheelToggle;
	public AudioSource engine,audio;
	public AudioClip crash;


	void Start(){
		Application.targetFrameRate = 100;
		if (PlayerPrefs.GetInt ("Restart", 0) == 0) {
			Application.LoadLevel (0);
			PlayerPrefs.SetInt("Restart",1);
		}

		volume = PlayerPrefs.GetFloat ("Volume",1);

		vol.value = volume;
		engine.volume = volume;

		tilt=PlayerPrefs.GetInt ("tiltToggle",0)==1;
		tiltToggle.isOn = tilt;

		sliderToggle.isOn = PlayerPrefs.GetInt ("slideToggle", 0)==1;
		slider.SetActive (sliderToggle.isOn);

		steeringWheelToggle.isOn= PlayerPrefs.GetInt ("steeringWheelToggles",1)==1;
		steeringWheel.SetActive (steeringWheelToggle.isOn);

		sens=PlayerPrefs.GetFloat("sensitivityValue",1);
		s.value = sens;

		pos = Vector3.zero;
		Time.timeScale = 0;
		if (res) {
			panel.SetActive (false);
			pause.SetActive (true);
			Time.timeScale = 1;
		//	Debug.Log (Roadmove.scrollSpeed+"lol");
		}
	}
	void Update() {
		if (Time.timeScale==1&&!engine.isPlaying&&!col) {
			engine.Play();
		}
		engine.pitch = 0.6f + Roadmove.scrollSpeed / 50;
		if (panel.activeSelf || settingsPanel.activeSelf) {
			if (!played) {
				if (col) {
					engine.Stop ();
					played = true;
					engine.PlayOneShot (crash);
				} 
				else
					engine.Pause ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
		if (!(panel.activeSelf || settingsPanel.activeSelf)) {

//			if (Time.timeScale == 1)
//					Time.timeScale = 0;
//			else
//					Time.timeScale = 1;

				Time.timeScale=0;
				panel.SetActive (true);
				pause.SetActive (false);
			}
		else if (panel.activeSelf) {
				exit();			
		}
			else{
				panel.SetActive (true);
				settingsPanel.SetActive (false);
			}
	//	HorseController.hurdle[(int)Random.Range(0,7.5f)].SetActive(true);
	}
}
	// Update is called once per frame
	void FixedUpdate () {
//		Vector3 v = cam.transform.position;
//		v.x =transform.position.x*0.9f;
//		cam.position = v;
		float hv = Input.GetAxis ("Horizontal");
		if (Input.touchCount >= 1&&!tilt)
			hv = Input.GetTouch (Input.touchCount - 1).position.x / (Screen.width / 2) - 1;
		if (tilt)
			hv = Input.acceleration.x;
		if (Mathf.Abs (hv) > Mathf.Abs (hvLast)||hv*hvLast<=0){
//			transform.rotation = Quaternion.Euler (0, 0, -hv * 30);
			hvLast = hv;
		
		}
	//	transform.rotation = Quaternion.Euler (0, 0, -hv * 20);

//		transform.rotation=Quaternion.Euler(0,0,210);
		steering.transform.localRotation=Quaternion.Euler(0,-hv*30*1.732f,-hv*30);
//		steering.transform
//		steering.transform.localRotation=Quaternion.Euler(45,0,60);
		angle = transform.eulerAngles.z * 3.14f / 180;
//		hPos = bar.transform.position;
//		hPos.x = 0;
		bar.localPosition = new Vector3 (hv*3, -5.27f, 0);

//		else transform.position += Vector3.right * hvLast / 15;
		if (!col) {
			pos += Vector3.right * Mathf.Abs (hvLast*5) * Mathf.Sign (hvLast) * Roadmove.scrollSpeed*sens / 10000;
			if (pos.x > 0.2f)
				pos.x = 0.2f;
			if (pos.x < -02f)
				pos.x = -0.2f;
			transform.position += pos / 2;
			transform.rotation=Quaternion.Euler(0f,0f,-pos.x*2000f/Roadmove.scrollSpeed);

		} else {
			transform.position = transform.position + Vector3.left * vibrate / 8;
			vibrate *= -1 /1.5f;
//			panel.SetActive(true);
//			pause.SetActive(false);
		}
//		if (!ini) {
//			if(Time.time-lastTime>1){
//				ini=true;
//				lastTime=Time.time;
//				Ins();
//			}
		}


//	void Ins(){
//		GameObject ga = (GameObject)Instantiate (cones,Vector3.up,Quaternion.Euler(0,0,0));
////		GameObject ga = (GameObject)Instantiate (cones);
//		ga.transform.SetParent (road);
//		ga.name = "kone";
//	}


//	void OnTriggerEnter(Collider other){
//	if (other.tag == "cone") {
////			other.attachedRigidbody.mass=1;
//			//other.transform.rotation=Quaternion.Euler(0,0,0);
////			other.attachedRigidbody.velocity=Vector3.forward*2;
//			//other.attachedRigidbody.AddForce(0,0,10000);
////			other.transform.position=Vector3.up;
//			Roadmove.scrollSpeed/=3;
//	//		transform.position=pos+ Vector3.zero;
//			col = true;
//		}
//	}
	void OnCollisionEnter(Collision other){
		engine.PlayOneShot(crash);
		Roadmove.scrollSpeed/=3;
		col = true;
		panel.SetActive (true);
		pause.SetActive (false);
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(FenceMove.score > oldHighscore)
			PlayerPrefs.SetInt("highscore", FenceMove.score);
		highScore.text="High Score: "+PlayerPrefs.GetInt("highscore", 0).ToString();
		scoreMiddle.text = "Score:"+FenceMove.score;
		scoreMiddle.gameObject.SetActive (true);

	}
	public void play(){
		if(Time.timeScale==1)Time.timeScale=0;
		else Time.timeScale=1;
		panel.SetActive (!panel.activeSelf);
		pause.SetActive (!pause.activeSelf);
	}
	public void exit(){
		PlayerPrefs.SetInt("Restart",0);
		Application.Quit ();
	}
	public void restart(){
		res = true;
		col = false;
		Time.timeScale = 1;
		Application.LoadLevel(0);
		//		panel.SetActive (true);
		//		pause.SetActive (false);
		//		Time.timeScale = 1;
	}
	public void settings(){
		panel.SetActive (false);
		settingsPanel.SetActive (true);
	}
	public void volumeChange(){
		volume = vol.value;
		PlayerPrefs.SetFloat ("Volume", volume);
		engine.volume = volume;
	}
	public void mainMenu(){
		panel.SetActive (true);
		settingsPanel.SetActive (false);
	}
	public void sensitivity(){
		sens = s.value;
		PlayerPrefs.SetFloat ("sensitivityValue", sens);
	}
	public void tiltToggler(){
		tilt = tiltToggle.isOn;
		PlayerPrefs.SetInt ("tiltToggle",(tilt ?1:0));
	}
	public void sliderToggler(){
		slider.SetActive (sliderToggle.isOn);
		PlayerPrefs.SetInt ("slideToggle",(sliderToggle.isOn ?1:0));
	}

	public void steeringToggler(){
		steeringWheel.SetActive (steeringWheelToggle.isOn);
		PlayerPrefs.SetInt ("steeringWheelToggles",(steeringWheelToggle.isOn ?1:0));
	}
}
