using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
	public void Transit ()
	{
		SceneManager.LoadScene ("Main");
		GetComponent<AudioSource> ().Play ();
	}

	public void SetMusic ()
	{
		Store.Music *= -1;
	}
}
