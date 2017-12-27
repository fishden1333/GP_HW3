using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour {

	public float timePass = 0;
  public Text text;
	public static float score;

	void Start()
	{
		text = GameObject.Find("Score").GetComponent<Text>();
	}

  void Update()
  {
      timePass += Time.deltaTime;
			score = Mathf.Round(timePass);
      text.text = score.ToString();
  }
}
