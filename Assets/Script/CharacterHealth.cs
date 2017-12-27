using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour {

	private bool isDead;

	// Use this for initialization
	void Start () {
		isDead = false;
	}

	// Update is called once per frame
	void Update () {
		if (isDead)
		{
			StartCoroutine("GameOver");
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
    if (coll.gameObject.tag == "Die")
		{
			isDead = true;
			StartCoroutine("GameOver");
		}
  }

	IEnumerator GameOver()
	{
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadSceneAsync("EndMenu");
	}
}
