using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{

	public static BGMScript Instance {
		get;
		private set;
	}

	void Awake ()
	{
		if (Instance != null && Instance != this) {
			Debug.Log ("Destroy BGMScript parent.1!!!!");
			DestroyObject (this.gameObject);
		} else { // Instance is NULL.
			Instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
	}
}
