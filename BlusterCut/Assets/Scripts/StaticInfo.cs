using UnityEngine;
using System.Collections;

public class StaticInfo : MonoBehaviour {

	public static int scores;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
