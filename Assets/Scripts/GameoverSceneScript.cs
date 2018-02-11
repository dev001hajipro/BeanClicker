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
}
