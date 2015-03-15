using UnityEngine;
using System.Collections;

public class PouletControls : MonoBehaviour {
	Animator anim;
	public float rotationAngle, translationValue, flapForce; 
	private Vector3 rotation, translate;
	private bool button, landed;
	private float axisX, axisY;

	void Start () {
		anim = GetComponent<Animator> ();
		rotation = new Vector3 (0.0f, rotationAngle, 0.0f);
		translate = new Vector3 (0.0f, 0.0f, translationValue);
		button = false;
		landed = false;
		axisX = 0.0f;
		axisY = 0.0f;
	}

	void OnCollisionStay(Collision collision){
		if (collision.gameObject.tag == "plateforme" || collision.gameObject.tag == "terrain") {
			landed = true;
		}
	}

	void OnCollisionExit(Collision collision){
		if (collision.gameObject.tag == "plateforme" || collision.gameObject.tag == "terrain") {
			landed = false;
		}
	}

	void Update () {
		//Turn Left/Right
		axisX = Input.GetAxis ("Horizontal");
		rotation = new Vector3 (0.0f, rotationAngle * axisX, 0.0f);
		transform.Rotate (rotation);

		//Animations
		if (landed) {
			anim.SetBool("inFlight",false);
		}
		else {
			anim.SetBool("inFlight",true);
		}

		//World Borders
		rigidbody.position = new Vector3 (rigidbody.position.x,Mathf.Clamp (rigidbody.position.y, -0.5f, 200f), rigidbody.position.z );

	}
	
	void FixedUpdate(){
		//Go forward/backward
		axisY = Input.GetAxis ("Vertical");
		translate = new Vector3 (translationValue * axisY, 0.0f, 0.0f);
		rigidbody.AddRelativeForce (translate);

		//Flap, flap, flap
		button = Input.GetKey ("space");
		if (button){
			rigidbody.AddForce (transform.up * flapForce);
		}
	}
}
