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

		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movePraFrente = camera.forward * moveVertical * Time.deltaTime * velocidade;
		transform.Translate (movePraFrente);

		Vector3 moveProLado = camera.right * moveHorizontal * Time.deltaTime * velocidade;
		transform.Translate (moveProLado);


	}
}
