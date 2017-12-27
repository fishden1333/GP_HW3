using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour {

	private ScoreTimer sc;
	private float score;
	private float record;
	public Text text;

	// Use this for initialization
	void Start () {
		sc = GetComponent<ScoreTimer>();
		record = 0;
	}

	// Update is called once per frame
	void Update () {
		if (score > record)
		{
			record = score;
		}
		text.text = "Score: " + score.ToString();
	}
}
