using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BGMScript : MonoBehaviour
{
	public static BGMScript Instance {
		get;
		private set;
	}

	public AudioMixer audioMixer;
	public AudioMixerSnapshot BGMOnSnapshot;
	public AudioMixerSnapshot BGMOffSnapshot;

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
		Debug.Log ("OnValueChanged: " + on);
		Store.Music = on ? 1 : 0;
		if (on) {
			// off -> on
			BGMOnSnapshot.TransitionTo (1.0f);
		} else {
			// on -> off
			BGMOffSnapshot.TransitionTo (1.0f);
		}
	}
}
