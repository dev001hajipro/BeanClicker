using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverSceneScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void PlaySE ()
	{
		GetComponent<AudioSource> ().Play ();
	}

	public void TransitToTitle ()
	{
		PlaySE ();
		SceneManager.LoadScene ("Title");
	}

	public void TransitToMain ()
	{
		PlaySE ();
		SceneManager.LoadScene ("Main");
	}
}
