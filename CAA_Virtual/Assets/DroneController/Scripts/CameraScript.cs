using UnityEngine;
using System.Collections;
using UnityEngine.VR;
public class CameraScript : MonoBehaviour {

	private GameObject ourDrone;
	void Awake(){
		InputTracking.Recenter();
		ourDrone = GameObject.FindGameObjectWithTag("Player").gameObject;
		Input.gyro.enabled = true;
	}
	private Vector3 velocitiCameraFollow;
	public Vector3 positionBehindDrone = new Vector3(0,2,-4);
	void FixedUpdate(){
		
		FollowDroneMethod();

		FreeMouseMovementView();

		ScrollMath();

	}
	[Range(0.0f,0.1f)]
	public float cameraFollowPositionTime = 0.1f;
	void FollowDroneMethod(){
		transform.position = Vector3.SmoothDamp(transform.position, ourDrone.transform.TransformPoint(positionBehindDrone + new Vector3(0, yScrollValue, zScrollValue)), ref velocitiCameraFollow, cameraFollowPositionTime);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.U)){
			InputTracking.Recenter();

		}
		VRMovement();

	}
	private float x_Rotation, y_Rotation;
	public Transform VR_rotator;
	void VRMovement(){
		if(gameObject.name.Contains("VR")){
			x_Rotation -= Input.gyro.rotationRateUnbiased.x;
			y_Rotation -= Input.gyro.rotationRateUnbiased.y;

			transform.rotation = Quaternion.Euler(new Vector3(14,ourDrone.GetComponent<DroneMovementScript>().currentYRotation,0));
			VR_rotator.rotation = Quaternion.Euler(new Vector3(14,ourDrone.GetComponent<DroneMovementScript>().currentYRotation,0)) * Quaternion.Euler(x_Rotation, y_Rotation, 0);
		}
	}
	public bool freeMouseMovement = false;
	private float mouseXwanted,mouseYwanted;
	public float mouseSensitvity = 100;
	private float currentXPos, currentYPos;
	private float xVelocity, yVelocity;
	public float mouseFollowTime = 0.2f;
	void FreeMouseMovementView(){
		if(freeMouseMovement == true){
			mouseXwanted -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitvity;
			mouseYwanted += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitvity;

			currentXPos = Mathf.SmoothDamp(currentXPos, mouseXwanted, ref xVelocity, mouseFollowTime);
			currentYPos = Mathf.SmoothDamp(currentYPos, mouseYwanted, ref yVelocity, mouseFollowTime);

			transform.rotation = Quaternion.Euler(new Vector3(14,ourDrone.GetComponent<DroneMovementScript>().currentYRotation,0)) *
				Quaternion.Euler(currentXPos, currentYPos, 0);

		}
		else{
			transform.rotation = Quaternion.Euler(new Vector3(14,ourDrone.GetComponent<DroneMovementScript>().currentYRotation,0));
		}
	}

	private float zScrollAmountSensitivity = 1, yScrollAmountSensitivity = -0.5f;
	private float zScrollValue, yScrollValue;
	void ScrollMath(){
		if (Input.GetAxis("Mouse ScrollWheel") != 0f ){
			zScrollValue += Input.GetAxis("Mouse ScrollWheel") * zScrollAmountSensitivity;
			yScrollValue += Input.GetAxis("Mouse ScrollWheel") * yScrollAmountSensitivity;
		}
	}

}
