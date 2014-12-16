using UnityEngine;
using System.Collections;

public class ParticleAutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, particleSystem.duration * 2f);	
	}
	
}
