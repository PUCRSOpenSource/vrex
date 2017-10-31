using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 5f;
	public Transform cameraTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis("Horizontal");
		Vector3 movement = cameraTransform.forward * moveVertical * speed * Time.deltaTime;
		transform.Translate (movement);
		movement = cameraTransform.right * moveHorizontal * speed * Time.deltaTime;
		transform.Translate (movement);
	}
}
