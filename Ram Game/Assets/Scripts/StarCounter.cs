using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour {

	public Text starProgress;
	public static int collectedStars = 0;
	int totalStars;

	void Start () {
		GameObject[] stars;
		stars = GameObject.FindGameObjectsWithTag ("Star");
		totalStars = stars.Length;

	}

	void Update () {
		starProgress.text = collectedStars + "/" + totalStars;
	}

}