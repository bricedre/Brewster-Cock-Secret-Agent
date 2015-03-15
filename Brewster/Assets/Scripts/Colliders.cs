using UnityEngine;
using System.Collections;

public class Colliders : MonoBehaviour {

	private bool touched;
	private GameObject reference;
	public GUIText countingThing;

	// Use this for initialization
	void Start () {
		touched = false;
	}

	void Update(){
		if (touched) {
			transform.position = new Vector3(reference.transform.position.x, reference.transform.position.y - 1.0f, reference.transform.position.z);
			transform.rotation = reference.transform.rotation;

		}

		if(transform.position.x > -10.0f && transform.position.x < 14.0f && transform.position.y > 82.0f && transform.position.y < 84.0f && transform.position.z > -10.0f && transform.position.z < 14.0f){
			Debug.Log("boxDestoyed!");
			Destroy(this.gameObject);
			countingThing.GetComponent<BoxesRecoverd>().boxes++;
		}
	}

	void OnCollisionStay(Collision collision){
		if(!touched){
			if (collision.gameObject.tag == "Player") {
				reference = collision.gameObject;
				Debug.Log("boxTaken!");
				touched = true;
			}
		}
	}
}
