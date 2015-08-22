using UnityEngine;
using System.Collections;

public class RotateOnTouch : MonoBehaviour {
	float h;
	float v;
	float horizontalSpeed = 1.0F;
	float verticalSpeed = 1.0F;
	
	// A setting you might want to allow access to?
	float sensitivity = 1.0F;
	
	Vector3 lastMousePosition;
	GameObject mainCamera;
	
	// Use this for initialization
	void Start () {
		lastMousePosition = Vector3.zero;
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1){
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Moved){
				h = horizontalSpeed * touch.deltaPosition.x * sensitivity;
				//				transform.Rotate (0, -h, 0, Space.World);
				transform.RotateAround(transform.position, mainCamera.transform.up, -h);
				
				v = verticalSpeed * touch.deltaPosition.y * sensitivity;
				//				transform.Rotate (v, 0, 0, Space.World);
				transform.RotateAround (transform.position, mainCamera.transform.right, v);
			}
		} else if (Input.GetMouseButton(0) == true) { // Mouse control
			if(Input.GetMouseButtonDown(0)){ lastMousePosition = Input.mousePosition;}
			transform.Rotate(Vector3.down * (Input.mousePosition.x - lastMousePosition.x), Space.World);
			transform.Rotate(Vector3.right * (Input.mousePosition.y - lastMousePosition.y), Space.World);
			lastMousePosition = Input.mousePosition;
		} 
	}
}
