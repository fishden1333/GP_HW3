﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void StartGame()
	{
		SceneManager.LoadSceneAsync("Game");
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void Controll()
	{
		
	}
}
