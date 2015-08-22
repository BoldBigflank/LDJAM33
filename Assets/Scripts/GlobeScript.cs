using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobeScript : MonoBehaviour {
	
	public GameObject hexagonObject;
	public GameObject pentagonObject;
	
	Vector3[] hexagonRotations = new[] {
		new Vector3(0.0F, 0.0F, 0.0F),
		new Vector3(0.0F, 0.0F, 72.0F),
		new Vector3(0.0F, 0.0F, 144.0F),
		new Vector3(0.0F, 0.0F, 216.0F),
		new Vector3(0.0F, 0.0F, 288.0F),
		new Vector3(0.0F, -63.5F, 36.2F)
	};
	
	// Use this for initialization
	void Start () {
		// Make 12 Pentagons
		for(int i = 0; i < hexagonRotations.Length; i++){
			GameObject pentagon = NewObjectPoolerScript.current.Spawn(pentagonObject.name);
			pentagon.transform.parent = transform;
			pentagon.transform.localRotation = Quaternion.Euler(hexagonRotations[i]);
			pentagon.transform.localScale = Vector3.one;
			pentagon.SetActive(true);
			
			GameObject mirrorPentagon = NewObjectPoolerScript.current.Spawn(pentagonObject.name);
			mirrorPentagon.transform.parent = transform;
			mirrorPentagon.transform.localRotation = Quaternion.Euler(hexagonRotations[i]);
			mirrorPentagon.transform.localScale = -1.0F * Vector3.one;
			mirrorPentagon.SetActive(true);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
