using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{

	public int Score = 0;
	public Text scoreText;
	public int killCount = 0;

	public void addPoint (int n = 10)
	{
		Score += n;
		scoreText.text = "Score:" + (Score.ToString ("0000"));

		if (Score > Store.HiScore) {
			Store.HiScore = Score;
		}

		killCount++;
		var o = GameObject.Find ("SpawnOwner");
		if (o != null && killCount % 10 == 0) {
			o.GetComponent<SpawnScript> ().spawnFaster ();
		}
	}
}
