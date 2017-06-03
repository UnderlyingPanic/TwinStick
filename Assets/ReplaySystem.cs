using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 1000;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

	private GameManager gameManager;
	private Rigidbody rigidBody;
	private bool recording;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.recording) {
			Record ();
		} else {
			PlayBack ();
		}
	}

	void Record () {
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
		rigidBody.isKinematic = false;
	}

	void PlayBack () {
		rigidBody.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;
		print ("Reading Frame " + frame);
		transform.position = keyFrames [frame].position;
		transform.rotation = keyFrames [frame].rotation;
	}
}




/// <summary>
/// A Structure for storing time, rotation, and position
/// </summary>
public struct MyKeyFrame {
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation) {
		frameTime = aTime;
		position = aPosition;
		rotation = aRotation;
	}
}
