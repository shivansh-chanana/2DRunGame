using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControllerScript : MonoBehaviour {

	public Rigidbody2D player;

	public PhysicsMaterial2D bounce; 
	public PhysicsMaterial2D noBounce;

	public 	Material whiteMat;
	public 	Material yellowMat;

	public SpriteRenderer playerMat;

	float jumpForce = 7f;

	bool down = false;

	float startPosX = 0f; 

	public RespawnScript rS;

	public ParticleSystem particleSys;

	Animator anim;

	void Start () {

		anim = GetComponent<Animator> ();

		startPosX = transform.position.x;

		player.sharedMaterial = bounce;
		playerMat.material = whiteMat;
	}
	
	// Update is called once per frame
	void Update () {

		if (down) {
			anim.SetBool ("Down_anim", true);
		}
		if (!down) {
			anim.SetBool ("Down_anim", false);
		}
		if (startPosX < transform.position.x) 
			transform.position = new Vector2(Mathf.Lerp(transform.position.x , startPosX , 0.05f) , transform.position.y);
				else if (startPosX > transform.position.x) transform.position = new Vector2(Mathf.Lerp(transform.position.x , startPosX , 0.05f),transform.position.y);

		if(Input.GetKeyDown(KeyCode.Z)) Jump();
		if(Input.GetKeyDown(KeyCode.X)) Down();

	}

	public void Jump(){
		//player.AddForce(new Vector2(0,jumpForce * Time.fixedDeltaTime * 1000 * 10));
		particleSys.Stop();
		anim.SetBool("Jump_anim",true);
		player.velocity = Vector2.up * jumpForce * Time.fixedDeltaTime * 60;
		player.sharedMaterial = bounce;
	}

	public void Down(){

		if (!down) {
			down = true;
			player.velocity = Vector2.down * jumpForce * 2 * Time.fixedDeltaTime * 60;
			player.sharedMaterial = noBounce;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag != "UpGround") anim.SetBool ("Jump_anim", false);

		if (col.gameObject.tag == "Ground") {
			down = false;
			particleSys.Play();
		}
			if (col.gameObject.tag == "Enemy") {
			if (down)
				Destroy (col.gameObject);
			else
				Destroy (this.gameObject);	
		
		}
	}

	void OnCollisionStay2D(Collision2D col){
		if (down)
			down = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "endPoint")
			rS.ReSpawn ();
	}

}
