using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Logros {
	
	public Logro[] logros;

	private int NUMERO_LOGROS = 7;
	  
	public Logros(){
		logros = new Logro[NUMERO_LOGROS];
		generarLogros ();
	}

	public bool ActualizarLogros(EstadoJuego e) {
		bool logroDesbloqueado = false;

		for (int i = 0; i < logros.Length && !logroDesbloqueado; i++) {

			if (!logros[i].desbloqueado) {
				logros[i].desbloqueado = logros[i].condicion(e);
				if (logros[i].desbloqueado) {
					logroDesbloqueado = true;
				}
			}
		}
		return logroDesbloqueado;
	}

	private ArrayList logrosDesbloqueados(EstadoJuego e) {
		ArrayList desbloqueados = new ArrayList ();
		for (int i = 0; i < logros.Length; i++) {	
			if (!logros[i].desbloqueado) {
				logros[i].desbloqueado = logros[i].condicion(e);
				if (logros[i].desbloqueado) {
					desbloqueados.Add(logros[i]);
				}
			}
		}
		return desbloqueados;
	}

	private void generarLogros() {
		logros [0] = CorreForrest ();
		logros [1] = muchosSeven1 ();
		logros [2] = muchosPadrino1 ();
		logros [3] = muchosVader1 ();
		logros [4] = muchosSeven1 ();
		logros [5] = muchosResplandor1 ();
		logros [6] = muchosHal90001 ();
	}


/************ LOGROS FORREST GUMP *****************/
	private Logro CorreForrest() {
		Logro l = new Logro();
		l.nombre = "Jump Forrest, Jump!";
		l.descripcion = "Collect 100 feathers";
		l.desbloqueado = false;
		l.condicion = suficientesForrest1;
		return l;
	}

	private bool suficientesForrest1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Forrest"] >= 100;
	}

/************ LOGROS SEVEN *****************/
	private Logro muchosSeven1() {
		Logro l = new Logro();
		l.nombre = "77 boxes";
		l.descripcion = "Collect 77 boxes";
		l.desbloqueado = false;
		l.condicion = suficientesSeven1;
		return l;
	}

	private bool suficientesSeven1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Seven"] >= 77;
	}

/************ LOGROS Padrino *****************/
	private Logro muchosPadrino1() {
		Logro l = new Logro();
		l.nombre = "I am gonna give you an Oscar you can't refuse";
		l.descripcion = "Collect 100 horse heads";
		l.desbloqueado = false;
		l.condicion = suficientesPadrino1;
		return l;
	}

	private bool suficientesPadrino1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Padrino"] >= 100;
	}

/************ LOGROS Hal9000 *****************/
	private Logro muchosHal90001() {
		Logro l = new Logro();
		l.nombre = "77 boxes";
		l.descripcion = "Collect 100 Hal9000";
		l.desbloqueado = false;
		l.condicion = suficientesHal90001;
		return l;
	}

	private bool suficientesHal90001(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Hal9000"] >= 100;
	}

	private Logro muchisimosHal90001() {
		Logro l = new Logro();
		l.nombre = "Infinite runner master";
		l.descripcion = "Collect 9000 Hal9000!!!";
		l.desbloqueado = false;
		l.condicion = demasiadosHal90001;
		return l;
	}
	
	private bool demasiadosHal90001(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Hal9000"] >= 9000;
	}


/************ LOGROS Star Wars *****************/
	private Logro muchosVader1() {
		Logro l = new Logro();
		l.nombre = "Awkard breathing";
		l.descripcion = "Collect 1000 Darth Vader Helmets";
		l.desbloqueado = false;
		l.condicion = suficientesVader1;
		return l;
	}

	private bool suficientesVader1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Vader"] >= 100;
	}
	

/************ LOGROS Resplandor *****************/
	
	private Logro muchosResplandor1() {
		Logro l = new Logro();
		l.nombre = "Here comes 1000 Johnies!";
		l.descripcion = "Collect 100 axes";
		l.desbloqueado = false;
		l.condicion = suficientesResplandor1;
		return l;
	}

	private bool suficientesResplandor1(EstadoJuego estadoJuego) {
		return EstadoJuego.estadoJuego.objetos_guardados["Resplandor"] >= 100;
	}
}

public delegate bool Condicion(EstadoJuego estadoJuego);

[Serializable]
public struct Logro {
	public string nombre;
	public string descripcion;
	public bool desbloqueado;
	public Condicion condicion;
}