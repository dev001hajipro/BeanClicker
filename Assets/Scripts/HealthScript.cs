using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
	void Awake ()
	{
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
	}

	void SceneManager_sceneLoaded (Scene arg0, LoadSceneMode arg1)
	{
		Debug.Log ("***HealthScript SceneManager_sceneLoaded");
		Reset ();
		for (int i = 0; i < healthMax; i++) {
			var o = GameObject.Find ("Heart" + i);
			if (o)
				o.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	private int healthCount = 3;
	public int healthMax = 3;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void takeDamage ()
	{
		healthCount--;

		for (int i = 0; i < healthMax; i++) {
			var o = GameObject.Find ("Heart" + i);
			o.GetComponent<SpriteRenderer> ().enabled = (i < healthCount);
		}

		if (healthCount < 0)
			SceneManager.LoadScene ("Gameover");
	}

	public void Reset ()
	{
		healthCount = healthMax;
	}
}
