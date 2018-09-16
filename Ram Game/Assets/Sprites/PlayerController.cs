using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 8;
	public float jumpHeight = 12;
	public Transform feetPos;
	public LayerMask groundLayer;
	public Animator animator;

	private Rigidbody2D rb;
	private float moveInput;
	private bool isGrounded;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {

		moveInput = Input.GetAxisRaw ("Horizontal");
		rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
		animator.SetFloat ("Speed", Mathf.Abs (moveInput));
		if (rb.velocity.x > 0) {

			transform.localScale = new Vector3 (1, transform.localScale.y, transform.localScale.z);
		}
		if (rb.velocity.x < 0) {
			transform.localScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);

		}
	}

	void Update () {

		isGrounded = Physics2D.OverlapBox (feetPos.position, feetPos.GetComponent<BoxCollider2D> ().size, 0, groundLayer);

		if (isGrounded && (Input.GetAxis ("Vertical") > 0 || Input.GetButtonDown("Fire1"))) {
			rb.velocity = Vector2.up * jumpHeight;

		}
		animator.SetBool ("IsJumping", !isGrounded);
	

	}
}