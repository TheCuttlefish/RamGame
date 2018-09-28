using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour {

	public Text starProgress;
	public static int collectedStars;
	public UnityEvent allStarsCollected;

	private int totalStars;

	void Start () {
		collectedStars = 0;
		GameObject[] stars;
		stars = GameObject.FindGameObjectsWithTag ("Star");
		totalStars = stars.Length;
	}

	void Update () {
		starProgress.text = collectedStars + "/" + totalStars;

		if (collectedStars == totalStars) {
			allStarsCollected.Invoke ();
		}
	}

}