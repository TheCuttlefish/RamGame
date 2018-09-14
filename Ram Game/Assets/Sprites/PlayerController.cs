using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed; // default 8
	public float jumpHeight; // default 12
	public Transform feetPos;
	public LayerMask groundLayer;

	private Rigidbody2D rb;
	private float moveInput;
	private bool isGrounded;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		moveInput = Input.GetAxisRaw ("Horizontal");
		rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
	}

	void Update () {

		isGrounded = Physics2D.OverlapBox (feetPos.position, feetPos.GetComponent<BoxCollider2D> ().size, 0, groundLayer);

		if (isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			rb.velocity = Vector2.up * jumpHeight;
		}

	}
}