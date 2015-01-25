using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuego : MonoBehaviour {

	public int puntuacionMaxima;

	public static EstadoJuego estadoJuego;
	private String directorioArchivo;

	void Awake() {
		directorioArchivo = Application.persistentDataPath + "/datosJuego.dat";
		//Impide que se destruya EstadoObjto al cambiar de escena
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
		} else if (estadoJuego != this) {
			Destroy(gameObject);		       
		}
	}

	// Use this for initialization
	void Start () {
		Cargar ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Cargar() {
		if (File.Exists(directorioArchivo)) {
		    BinaryFormatter bf = new BinaryFormatter ();
		    FileStream file = File.Open (directorioArchivo, FileMode.Open);

		    DatosAGuardar datos = (DatosAGuardar) bf.Deserialize (file);

		    puntuacionMaxima = datos.puntuacionMaxima;
		} else {
			puntuacionMaxima = 0;
		}

	}

	public void Guardar() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(directorioArchivo);

		DatosAGuardar datos = new DatosAGuardar (puntuacionMaxima);

		bf.Serialize (file, datos);
		file.Close ();
	}
	
}

[Serializable]
class DatosAGuardar {
	public int puntuacionMaxima;

	public DatosAGuardar(int puntuacionMaxima) {
		this.puntuacionMaxima = puntuacionMaxima;
	}
}
