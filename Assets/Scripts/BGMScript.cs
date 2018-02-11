using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMScript : MonoBehaviour
{
	public static BGMScript Instance {
		get;
		private set;
	}

	void Awake ()
	{
		if (Instance != null && Instance != this) {
			DestroyObject (this.gameObject);
		} else { // Instance is NULL.
			Instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
	}

	void Start ()
	{
		var o = GameObject.Find ("Toggle").GetComponent<Toggle> ();
		o.isOn = (Store.Music == 1) ? true : false;
	}

	public void OnValueChanged (bool on)
	{
		Store.Music = on ? 1 : 0;
	}
}
