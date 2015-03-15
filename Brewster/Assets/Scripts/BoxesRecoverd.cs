using UnityEngine;
using System.Collections;

public class BoxesRecoverd : MonoBehaviour {
	
	public int boxes;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = "Boxes Recovered : " + boxes + "/10";
	}
}
