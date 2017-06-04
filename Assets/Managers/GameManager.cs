using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	private float fixedDeltaTime;
	public bool recording = true;

	void Start () {
		PlayerPrefsManager.UnlockLevel (1);
		PlayerPrefsManager.UnlockLevel (2);
//		print (PlayerPrefsManager.IsLevelUnlocked(1));
//		print (PlayerPrefsManager.IsLevelUnlocked(2));
//		print (PlayerPrefsManager.IsLevelUnlocked(3));

		fixedDeltaTime = Time.fixedDeltaTime;

	}

	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
			recording = false;
		} else {
			recording = true;
		}
		if (CrossPlatformInputManager.GetButtonDown ("Pause")) {
			PauseGame ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			ResumeGame();
		}
		print (Time.fixedDeltaTime);
	}

	void PauseGame () {
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	void ResumeGame () {
		Time.timeScale = 1;
		Time.fixedDeltaTime = fixedDeltaTime;
	}
}
