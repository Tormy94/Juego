using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		ActualizarMarcador ();
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
	}

	void IncrementarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion+=puntosAIncrementar;
		ActualizarMarcador ();
	}

	//Si se ha superado el record de puntuacion, se guarda
	void PersonajeHaMuerto(Notification not){
		if (puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima) {
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar();
		}
	}

	void ActualizarMarcador(){
		marcador.text = puntuacion.ToString ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
