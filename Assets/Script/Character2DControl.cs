﻿using UnityEngine;
using System.Collections;

public class Character2DControl : MonoBehaviour
{
	private Character2D character;
	private bool jump;
	private float movingSpeed;

	// Use this for initialization
	void Start ()
	{
		character = GetComponent<Character2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		//get jump input by "jump" button set in input setting
		if (Input.GetButtonDown("Jump")) jump = true;
	}

	void FixedUpdate()
	{
		//get input by Axis set in input setting
		movingSpeed = Input.GetAxis("Horizontal");

		//pass parameters to character script, and then it can move
		character.Move(movingSpeed, jump);

		//jump is reset after each time that physical engine updated
		jump = false;
	}
}
