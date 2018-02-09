using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{

	public int Score = 0;
	public Text scoreText;
	public int killCount = 0;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void addPoint (int n = 10)
	{
		Score += n;
		scoreText.text = "Score: " + (Score.ToString ("00000"));

		killCount++;
		var o = GameObject.Find ("SpawnOwner");
		if (o != null && killCount % 10 == 0) {
			Debug.Log ("spawnFaster");
			o.GetComponent<SpawnScript> ().spawnFaster ();
		}

	}
}
