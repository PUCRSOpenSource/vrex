using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentos_Elevator : MonoBehaviour {
	private bool movendoPraCima;
	private bool movendo;
	public float tempoRestante = 5f;
	private Rigidbody rb;
	public float velocidade = 5f;

	// Use this for initialization
	void Start () {
		movendo = false;
		movendoPraCima = true; //decide a direção quando ele se mover
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!movendo){
			tempoRestante -= Time.deltaTime; // tempo que se passou de cada  frame
			if (tempoRestante <= 0) {
				movendo = true;
				tempoRestante = 5f;
			}
		
		} else {
			if (movendoPraCima){
				rb.MovePosition (transform.position + transform.up * Time.deltaTime * velocidade);
				if (transform.position.y >= 10) {
					rb.MovePosition (new Vector3(transform.position.x, 10, transform.position.z));
					movendo = false;
					movendoPraCima = false; 
				}
			
			} else {
				rb.MovePosition (transform.position - transform.up * Time.deltaTime * velocidade);
				if (transform.position.y <= 0) {
					rb.MovePosition (new Vector3(transform.position.x, 0, transform.position.z));
					movendo = false;
					movendoPraCima = true; 
				}
				
			}
		}
		
	}
}
