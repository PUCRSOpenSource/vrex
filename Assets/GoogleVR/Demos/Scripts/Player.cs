using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 3f;
	public Transform cameraTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = cameraTransform.forward * moveVertical * speed * Time.deltaTime;
		transform.Translate (movement);
	}
}
