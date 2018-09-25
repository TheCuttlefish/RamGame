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

	private float internal_dash;
	private Rigidbody2D rb;
	private float moveInput;
	private bool isGrounded;
	private int dashDuration = 15;
	private int dashCounter;
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

		moveInput = Input.GetAxisRaw ("Horizontal");
		rb.velocity = new Vector2 ((moveInput * speed) + internal_dash, rb.velocity.y);

		if (rb.velocity.x > 0) {
			transform.localScale = new Vector3 (1, transform.localScale.y, transform.localScale.z);
		}
		if (rb.velocity.x < 0) {
			transform.localScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);
		}

	}

	void Jump () {

		if (isGrounded && Input.GetButtonDown ("Jump")) {
			rb.velocity = Vector2.up * jumpHeight;
		}

		isGrounded = Physics2D.OverlapBox (feetPos.position, feetPos.GetComponent<BoxCollider2D> ().size, 0, groundLayer);

	}
	void Dash () {

		if (Input.GetButtonDown ("Dash") && allowDash) {

			allowDash = false;
			dashCounter = 0;
			internal_dash = dash * transform.localScale.x;
		}

		if (dashCounter < dashDuration) {
			dashCounter++;
		} else {
			internal_dash = 0;
			allowDash = true;
		}

	}

	void Animations () {

		animator.SetFloat ("Speed", Mathf.Abs (moveInput));
		animator.SetBool ("IsJumping", !isGrounded);
		animator.SetBool ("isDashing", !allowDash);
	}

}