using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour {

	private float timePass = 0;
  public Text text;
	public Text scoreText;
	static public float score;

	void Start()
	{
			text = GameObject.Find("Score").GetComponent<Text>();
			scoreText = GameObject.Find("Scoretext").GetComponent<Text>();
	}

  void Update()
  {
		if (text != null)
		{
			timePass += Time.deltaTime;
			score = Mathf.Round(timePass);
      text.text = score.ToString();
		}
		else if (scoreText != null)
		{
			scoreText.text = "Score: " + score.ToString();
		}
  }
}
