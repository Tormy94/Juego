using UnityEngine;
using System.Collections;

public class BotonCargarEscena : MonoBehaviour {

	public string escena;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Application.LoadLevel (escena);
	}
}
