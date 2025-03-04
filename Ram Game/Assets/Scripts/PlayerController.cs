using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 8;
	public float dash = 10;
	public float jumpHeight = 12;
	public Transform feetPos;
	public LayerMask groundLayer;
	public Animator animator;
	public bool allowDash = true;

	private float dashIntensity;
	private Rigidbody2D rb;
	private float horizInput;
	private bool isGrounded;
	private float dashDuration = 0.2f;
	private float dashCounter;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		
		Movement ();
		Jump ();
		Dash ();
		Animations ();
	}

	void Movement () {

		horizInput = Input.GetAxisRaw ("Horizontal");
		rb.velocity = new Vector2 ((horizInput * speed) + dashIntensity, rb.velocity.y);

		//flip the player's sprite based on the velocity
		if (rb.velocity.x > 0) {
			transform.localScale = new Vector3 (1, transform.localScale.y, transform.localScale.z);
		}
		if (rb.velocity.x < 0) {
			transform.localScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);
		}

	}

	void Jump () {
		
		isGrounded = Physics2D.OverlapBox (feetPos.position, feetPos.GetComponent<BoxCollider2D> ().size, 0, groundLayer);

		if (isGrounded && Input.GetButtonDown ("Jump")) {
			rb.velocity = Vector2.up * jumpHeight;
		}
	}
	void Dash () {

		if (Input.GetButtonDown ("Dash") && allowDash) {

			allowDash = false;
			
			dashCounter = 0;
			dashIntensity = dash * transform.localScale.x;
		}

		if (dashCounter < dashDuration) {
			dashCounter += Time.deltaTime;
		} else {
			dashIntensity = 0;
			allowDash = true;
		}

	}

	void Animations () {

		animator.SetFloat ("Speed", Mathf.Abs (horizInput));
		animator.SetBool ("IsJumping", !isGrounded);
		animator.SetBool ("isDashing", !allowDash);
	}

}