using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverSceneScript : MonoBehaviour
{
	void Start ()
	{
		GameObject.Find ("HiScore").GetComponent<Text> ().text
		= string.Format ("ハイスコア:{0}", Store.HiScore.ToString ("0000"));
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
