﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour {

	public Text levelCompleteText;
	public int newLevel = 0;
	private bool gotoNextLevel = false;
	private float waitTimer = 3;

	void Awake () {
		levelCompleteText.enabled = false;
	}

	public void ShowText () {
		levelCompleteText.enabled = true;
		gotoNextLevel = true;
	}

	void Update () {
		if (gotoNextLevel) {
			waitTimer-=Time.deltaTime;
			if (waitTimer < 0) {

				SceneManager.LoadScene (newLevel);

			}

		}
	}
}