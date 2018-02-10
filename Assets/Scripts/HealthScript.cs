using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
	private int healthCount = 3;
	public int healthMax = 3;

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
