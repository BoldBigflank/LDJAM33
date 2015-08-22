using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {

	AudioSource beat;
	float lastBeatTime;
	
	List<GameObject> globes;
	
	Camera mainCamera;
	GameObject player;
	
	// Use this for initialization
	void Start () {
		globes = new List<GameObject>();
		beat = gameObject.GetComponent<AudioSource>();
		beat.Play();
		lastBeatTime = beat.time;
		mainCamera = Camera.main;
		player = GameObject.FindGameObjectWithTag("Player");
		
		GameObject globe = NewObjectPoolerScript.current.Spawn("Globe");
		globe.SetActive(true);
		globes.Add(globe);
		
		player.transform.parent = globe.transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(beat.time < lastBeatTime){
			// We've looped, send an event
			UpdatePlayer ();
		}
		
		
		lastBeatTime = beat.time;
	}
	
	
	void UpdatePlayer(){
		Debug.Log ("Updating the player");
		// Send a ray to the origin from the camera (Ignoring the player).
		RaycastHit hit = new RaycastHit();
		
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 cameraPosition = mainCamera.transform.position;
		Vector3 fwd = -1.0F * cameraPosition;
		float dist = fwd.magnitude;
		
		if(Physics.Raycast (cameraPosition, fwd, out hit, dist)){
			Debug.Log ("Hit something" + hit.point);
			Debug.DrawRay(cameraPosition, fwd, Color.red, 1.0F );
			Transform objectHit = hit.transform;
			
			// If the objectHit is in the current globe
			player.transform.position = hit.point; // hit.rigidbody.centerOfMass;
			player.transform.LookAt(Vector3.zero);
			Debug.Log ("Center" + hit.rigidbody.centerOfMass);
			 
		}
		
		// TODO: Raycast should not hit player
		// If it hits a hexagon/pentagon in the current globe
			// Player moves to tile's center of mass.
	}
	
}
