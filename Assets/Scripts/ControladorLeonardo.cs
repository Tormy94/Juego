using UnityEngine;
using System.Collections;

public class ControladorLeonardo : MonoBehaviour {

	public float fuerzaSalto = 100f;
	private bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;
	
	private Animator animator;
	
	private bool corriendo = false;
	public float velocidad = 1f;
	

	void Awake() {
		animator = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "SaltoLeonardo");
	}

	void SaltoLeonardo(Notification notificacion){
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);
		rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
	}

	void FixedUpdate() {
		if (corriendo) {
			rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);
		}
		animator.SetFloat ("SpeedX", rigidbody2D.velocity.x);
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool ("isGrounded", enSuelo);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown (0)) {
			corriendo = true;
		}
	}
}
