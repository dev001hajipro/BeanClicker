using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{

	public int Score = 0;
	public Text scoreText;

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
	}
}
