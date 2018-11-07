using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegador : MonoBehaviour {
	GameObject cameraPrincipal;
	GameObject objetoQueVaiSerPego;

	bool carregando;
	public float suave = 10f;
	public float distancia = 2f;

	// Use this for initialization
	void Start () {

		cameraPrincipal = GameObject.FindWithTag ("MainCamera");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!carregando) { //se não estiver carregando
			pegarObjeto();
		} else {
			carregaObjeto (objetoQueVaiSerPego);
			checkSePrecisaLargarObjeto ();
		}		
	}

	void pegarObjeto(){		
		int x = Screen.width/2;         //centro do comprimento
		int y = Screen.height/2;		//centro da altura

		Ray raio = cameraPrincipal.GetComponent<Camera> ().ScreenPointToRay (new Vector3 (x, y));
		RaycastHit ondeEleBateu;
		if (Physics.Raycast (raio, out ondeEleBateu)) {
			Pegavel pegavel = ondeEleBateu.collider.GetComponent<Pegavel> (); //script do objeto

			if(pegavel!=null){
				carregando = true;
				objetoQueVaiSerPego = pegavel.gameObject;
				pegavel.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			}
		}
	}

	void checkSePrecisaLargarObjeto(){
		float angle = Vector3.Angle(Vector3.up, cameraPrincipal.transform.forward);
		if (angle < 80) {
			carregando = false;
			objetoQueVaiSerPego.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			objetoQueVaiSerPego = null;
		}
	}

	void carregaObjeto(GameObject objeto){
		objetoQueVaiSerPego.transform.position = Vector3.Lerp (objetoQueVaiSerPego.transform.position, cameraPrincipal.transform.position + cameraPrincipal.transform.forward * distancia, Time.deltaTime * suave);
	
			//interpolação entre 2 vetores (posição dele, e a posição da camera)
	}
}
