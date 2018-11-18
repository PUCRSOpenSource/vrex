using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimentos_Player : MonoBehaviour {
	public float velocidade = 5;
	public Transform camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float angle = Vector3.Angle(Vector3.up, camera.transform.forward);

		if (angle > 100) {
			Vector3 movePraFrente = camera.forward * (angle / 100) * Time.deltaTime * velocidade;
			transform.Translate (movePraFrente);
		} else {
			if (angle < 80) {
				Vector3 movePraFrente = -1 * camera.forward * (angle / 500) * Time.deltaTime * velocidade;
				transform.Translate (movePraFrente);
			}
		}
	}
}
