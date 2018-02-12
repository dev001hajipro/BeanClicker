using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class EnemyBehaviour : MonoBehaviour
{
	private Rigidbody2D mRigidBody2D;
	public int power = 1;
	private AudioSource tappedSE;
	private AudioSource explosionSE;
	public GameObject TapEffect;

	// Use this for initialization
	void Start ()
	{
		mRigidBody2D = GetComponent<Rigidbody2D> ();
		var direction = GetRandomVec2 ();
		mRigidBody2D.AddForce (direction * power, ForceMode2D.Impulse);
		// Unityエディターの最初のAUdioSourceをタップ音として使う。
		tappedSE = GetComponents<AudioSource> () [0];
		explosionSE = GetComponents<AudioSource> () [2];
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
			var healthObject = GameObject.Find ("Health");
			healthObject.GetComponent<HealthScript> ().takeDamage ();

			explosionSE.Play ();
			Destroy (gameObject, 0.2f);
		}
	}

	void Kill ()
	{
		var o = GameObject.Find ("Status");
		if (o != null) {
			o.GetComponent<StatusScript> ().addPoint ();
		}
		GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		// ParticleはUnityEditorのPlayOnAwakeにより実行される。
		var p = Instantiate (TapEffect, transform.position, Quaternion.identity);
		Destroy (p, p.GetComponent<ParticleSystem> ().main.duration + 0.2f); // 0.2f buffer.

		Destroy (gameObject, 0.1f);
	}
}
