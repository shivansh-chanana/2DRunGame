using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_ObstacleCreate : MonoBehaviour {

	public GameObject[] obstacle;
	public GameObject startPoint;

	bool createNow = true;

	float startTime = 1; //But it is changed in update method to RespawnScript.createSpeed
	//public float endTime = 5;

	int randNo = 0;

	void Update () {

		startTime = RespawnScript.createSpeed;

		if (createNow) {
			Invoke ("CreateObstacle", startTime * Time.fixedDeltaTime * 60);
			createNow = false;
		}
	}

	void CreateObstacle(){

		randNo = Random.Range (0, 2);

		Instantiate (obstacle[randNo],new Vector2(startPoint.transform.position.x,startPoint.transform.position.y),Quaternion.identity);
		createNow = true;
	}
}
