using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float pitch,yaw;
	public float pitchAngle, yawAngle;
	public GameObject reference;
		
	void Update()
	{
		pitch = (Input.mousePosition.y-Screen.height/2) / (Screen.height/2);
		yaw = (Input.mousePosition.x-Screen.width/2) / (Screen.width/2);


		transform.rotation = Quaternion.Euler(0.0f,reference.transform.rotation.eulerAngles.y + yawAngle*yaw, reference.transform.rotation.eulerAngles.z + pitchAngle*pitch);
	}
}
