﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	public ParticleSystem particles;

	void Update () {
		transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + Mathf.Cos (Time.time * 10) / 150, transform.localPosition.z);
		transform.Rotate (0, 0, 1);
	}

	void OnTriggerStay2D (Collider2D other) {

		if (other.transform.tag == "Player") {
			StarCounter.collectedStars++;
			Instantiate (particles, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}