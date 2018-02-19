using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour {

	static public float globalMoveSpeed = 2f;
	static public float createSpeed = 1f;

	float speedIncTime;

	public GameObject player;

	bool incrementNow = true; 

	void Start () {
		speedIncTime = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C) || player==false)	
			ReSpawn ();
		if (incrementNow) {
			Invoke ("SpeedIncrease", speedIncTime * Time.fixedDeltaTime * 60);
			incrementNow = false;
		}
	}

	void SpeedIncrease(){
		
		if (globalMoveSpeed < 6.1f)
			globalMoveSpeed += 0.5f;
		if (createSpeed > 2)
			createSpeed -= 0.5f;
		
		Debug.Log ("move speed is now : " + globalMoveSpeed);
		Debug.Log ("create speed is now : " + createSpeed);

		incrementNow = true;
	}

	public void ReSpawn(){
		SceneManager.LoadScene ("main");
	}
}
