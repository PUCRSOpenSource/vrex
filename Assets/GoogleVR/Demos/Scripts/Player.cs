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
		Vector3 forwardMovement = cameraTransform.forward * moveVertical * speed * Time.deltaTime;
		transform.Translate (forwardMovement);
		float moveHorizontal = Input.GetAxis("Horizontal");
		Vector3 sidewaysMovements = cameraTransform.right * moveHorizontal * speed * Time.deltaTime;
		transform.Translate (sidewaysMovements);
	}
}
