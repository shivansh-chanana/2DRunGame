using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour {

	public Rigidbody2D enemyRb;

	public int enemyType = 0; 

	public GameObject enemyPrefab;
	public GameObject startPoint;

	public Transform playerPos;

	bool ground = false;

	float moveSpeed = 2f;//Move speed of Enemy //But it is changed in UpdateMethod with globalMoveSpeed;

	void Start () {
		
	}

	void Update () {
		moveSpeed = RespawnScript.globalMoveSpeed;

		if (ground) {
		enemyRb.velocity = Vector2.left * moveSpeed * Time.fixedDeltaTime * 60;
			if(enemyType == 1){
				if (playerPos == true) {
					if (transform.position.x < playerPos.position.x + 0.05f && transform.position.x > playerPos.position.x - 0.05f)
						enemyRb.velocity = Vector2.up * moveSpeed * Time.fixedDeltaTime * 60 * 10; 
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "endPoint") {
			//Instantiate (enemyPrefab,new Vector2(startPoint.transform.position.x,-0.9f),Quaternion.identity);
			DestroyObject (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ground")
			ground = true;
	}
}
