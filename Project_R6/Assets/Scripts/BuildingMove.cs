using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMove : MonoBehaviour {

	public Rigidbody2D buildingRb;

	public GameObject buildingPrefab;
	public GameObject startPoint;


	float moveSpeed = 2f; //Move speed of Building //But it is changed in UpdateMethod 

	bool ground = false;

	void Update () {
		moveSpeed = RespawnScript.globalMoveSpeed;

		if (ground) {
			buildingRb.velocity = Vector2.left * moveSpeed * Time.fixedDeltaTime * 60;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "endPoint") {
		//	Instantiate (buildingPrefab,new Vector2(startPoint.transform.position.x,-0.9f),Quaternion.identity);
			DestroyObject (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ground")
			ground = true;
	}
}

