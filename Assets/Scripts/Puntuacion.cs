using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;
	public TextMesh marcador;

	//La notificacion personaje muerto se llama dos veces por alguna razon, esto lo evita.
	private bool personajeMuerto;

	// Use this for initialization
	void Start () {
		personajeMuerto = false;
		ActualizarMarcador ();
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
	}

	void IncrementarPuntos(Notification notificacion){
		EstadoJuego.estadoJuego.objetos_guardados[notificacion.sender.tag]++;
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion+=puntosAIncrementar;
		ActualizarMarcador ();
	}

	//Si se ha superado el record de puntuacion, se guarda
	void PersonajeHaMuerto(Notification not){
		if (personajeMuerto) {
			return;
		}

		EstadoJuego.estadoJuego.objetos_guardados ["MuertesPersonaje"]++;

		if (puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima) {
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
		}
		EstadoJuego.estadoJuego.Guardar();
		personajeMuerto = true;
	}

	void ActualizarMarcador(){
		marcador.text = puntuacion.ToString ();
	}
	
}
