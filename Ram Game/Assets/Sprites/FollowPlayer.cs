using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform playerPos;
	public float speed = 2f;
	private Vector3 newPos;

	void Start () {

	}

	void Update () {
		newPos = new Vector3 (playerPos.transform.position.x, playerPos.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, newPos, speed * Time.deltaTime);
	}
}