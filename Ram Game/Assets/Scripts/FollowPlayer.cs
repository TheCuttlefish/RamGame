﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform playerPos;
	public float speed = 2f;
	private Vector3 newPos;

	void Start () {
		transform.position = new Vector3 (playerPos.position.x, playerPos.position.y, transform.position.z);
	}

	void Update () {
		newPos = new Vector3 (playerPos.position.x, playerPos.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, newPos, speed * Time.deltaTime);
	}
}