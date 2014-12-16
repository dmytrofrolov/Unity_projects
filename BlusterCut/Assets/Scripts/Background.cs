using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public float speed = 1;
	static int hello;

	// Use this for initialization
	void Start () {
		 hello+=1;
	}
	
	// Update is called once per frame
	void Update () {
		float amtToMove = speed * Time.deltaTime;
		transform.Translate(Vector3.down * amtToMove, Space.World);

		if(transform.position.y < -9.0f) transform.position = new Vector3(-0.61f, 18f, 0f);
	}
}
