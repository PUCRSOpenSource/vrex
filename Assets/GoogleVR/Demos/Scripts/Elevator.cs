using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	public float timeStopped;
	public float speed;

	private Rigidbody rb;
	private float timeLeft;
	private bool running;
	private bool moveUp;

	// Use this for initialization
	void Start () {
		timeStopped = 5f;
		speed = 5f;
		rb = GetComponent<Rigidbody> ();

		timeLeft = timeStopped;
		running = false;
		moveUp = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!running) {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				running = true;
			}
		} else {
			if (moveUp) {
				rb.MovePosition (transform.position + transform.up * Time.deltaTime * speed);
				if (transform.position.y >= 10) {
					rb.MovePosition (new Vector3(transform.position.x, 10, transform.position.z));
					running = false;
					timeLeft = timeStopped;
					moveUp = false;
				}
			} else {
				rb.MovePosition (transform.position - transform.up * Time.deltaTime * speed);
				if (transform.position.y <= 0) {
					rb.MovePosition (new Vector3(transform.position.x, 0, transform.position.z));
					running = false;
					timeLeft = timeStopped;
					moveUp = true;
				}
			}
		}
	}
}
