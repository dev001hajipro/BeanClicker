using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

	public GameObject target;
	public float seconds = 0.8f;
	public float sub = 0.01f;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine ("GenerateEnemy");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private IEnumerator GenerateEnemy ()
	{
		while (true) {
			float w = Random.Range (-1.1f, 1.1f);
			float h = Random.Range (0f, 2f);
			GameObject o = Instantiate (target);
			o.transform.position = new Vector3 (w, h, 0).normalized;
			yield return new WaitForSeconds (seconds);
		}
	}

	public void spawnFaster ()
	{
		seconds -= sub;
	}
}
