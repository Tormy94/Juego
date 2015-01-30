using UnityEngine;
using System.Collections;

public class GeneradorLeonardo : MonoBehaviour {

	public GameObject Leonardo;
	//GameObject oscar = GameObject.Find ("Player");
	private bool fin = false;

	// Use this for initialization
	void Start () {

		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
	}

	void PersonajeHaMuerto(){
		fin = true;
	}
	void PersonajeEmpiezaACorrer(Notification noficacion){
		Generar ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Leonardo(Clone)")== null) {
			Generar ();
		}
	}

	void Generar(){
		if (!fin) {
			Instantiate (Leonardo, transform.position, Quaternion.identity);
		}
	}
}
