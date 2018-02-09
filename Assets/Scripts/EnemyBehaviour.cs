﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
	private Rigidbody2D mRigidBody2D;
	public int power = 1;
	private AudioSource tappedSE;

	// Use this for initialization
	void Start ()
	{
		mRigidBody2D = GetComponent<Rigidbody2D> ();
		var direction = GetRandomVec2 ();
		mRigidBody2D.AddForce (direction * power, ForceMode2D.Impulse);
		Debug.Log ("do start.");
		// Unityエディターの最初のAUdioSourceをタップ音として使う。
		tappedSE = GetComponents<AudioSource> () [0];
	}

	static Vector2 GetRandomVec2 ()
	{
		return new Vector2 (Random.Range (-3, 3), Random.Range (-0.5f, 2.5f));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (OnTouch ()) {
			tappedSE.Play ();
			Kill ();
		}
			
	}

	bool OnTouch ()
	{
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
			foreach (var touch in Input.touches) {
				if (touch.phase == TouchPhase.Began) {
					if (RayHit (touch.position))
						return true;
				}
			}
		} else {
			// Unity Editor.
			const int LEFT_CLICK = 0;
			if (Input.GetMouseButtonDown (LEFT_CLICK)) {
				if (RayHit (Input.mousePosition))
					return true;
			}
		}
		return false;
	}

	private bool RayHit (Vector2 position)
	{
		Ray ray = Camera.main.ScreenPointToRay (position);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
		if (hit.collider) {
			if (hit.collider.gameObject == this.gameObject)
				return true;
		}
		return false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name.Equals ("Bottom")) {
			Debug.Log (gameObject);
			Destroy (gameObject);
		}
	}

	void Kill ()
	{
		Debug.Log ("Kill");
		var o = GameObject.Find ("Status");
		if (o != null) {
			o.GetComponent<StatusScript> ().addPoint ();
		}
		Destroy (gameObject, 0.2f);
	}
}
