using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate(0, speed, 0);
		if (transform.position.y <= -71)
		{
			speed = speed * -1;
		}
		else if (transform.position.y >= 1.4f)
		{
			speed = (speed + 0.01f) * -1;
		}
	}
}
