using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		string tag = other.tag;
		switch (tag) {
		case "Player":
			NotificationCenter.DefaultCenter().PostNotification(this,"PersonajeHaMuerto");
			GameObject player = GameObject.Find("Player");
			player.SetActive(false);
			break;
		case "Leonardo":
			//Quitar comentarios cuando hagamos la implementacion del contador de Leonardo
		//	NotificationCenter.DefaultCenter().PostNotification(this, "LeonardoHaMuerto");
			break;
		default: 
			Destroy (other.gameObject);
			break;
		}
	}
}
