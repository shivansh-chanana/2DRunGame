using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PowerUp : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;
	public float amplitude;

	Vector2 sinWave;

	// Use this for initialization
	void Start () {
		sinWave = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {

		sinWave.x += xSpeed;
		sinWave.y += Mathf.Sin (Time.realtimeSinceStartup * ySpeed) * amplitude;

		transform.position = sinWave;
	}
}
