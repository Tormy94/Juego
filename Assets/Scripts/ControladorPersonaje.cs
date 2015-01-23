using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto = 100f;
	private bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;

	private int maxSaltos = 2;
	private int saltosDados = 1;
	private Animator animator;

	private bool corriendo = false;
	public float velocidad = 1f;

	//Needed to get personaje's X and Y position
	public Transform personaje;
	public GameObject spring;


	void Awake(){
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate(){
		if (corriendo) {
			rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);
		}
		animator.SetFloat ("SpeedX", rigidbody2D.velocity.x);
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		//Reinicia el cuento de saltos en caso de que toque el suelo
		animator.SetBool ("isGrounded", enSuelo);
		if (enSuelo) {
			//dobleSalto = false;
			saltosDados = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (corriendo){
				if (saltosDados < maxSaltos) {
					//Creates a LeonardoJump point
					Instantiate (spring, personaje.position, Quaternion.identity);

					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
					rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));

					saltosDados++;
				}
			}
			else{
				corriendo = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
			}
		}
	}
}
