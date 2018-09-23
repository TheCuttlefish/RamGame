using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour {

	
	public ParticleSystem debris;

	void OnCollisionStay2D (Collision2D other) {

		if (other.transform.tag == "Player") {
			
			if(other.transform.GetComponent<PlayerController>().isDashing){
				
				if(other.transform.localPosition.y < transform.localPosition.y + 1.0f){
					Instantiate(debris, transform.position, Quaternion.identity);
					Destroy (gameObject);

				}
			}
		}
	}

}