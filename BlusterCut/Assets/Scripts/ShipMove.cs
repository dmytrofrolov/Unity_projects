using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour {
	
	public float startingLife = GameSettings.enemyLife;
	private float itsLife = GameSettings.enemyLife;
	public float currentSpeed = 2.5f;
	public GameObject explosionPrefab;
	private bool rightPressed = false, leftPressed = false;
	private float x, y, z;
	
	
	// Use this for initialization
	void Start () {
		//x = transform.position.x;
		y = 22f;
		z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		float amtToMove = currentSpeed * Time.deltaTime * Player.speedCoef;
		transform.Translate(Vector3.down * amtToMove, Space.World);
		
		if(transform.position.y < -7f)
		{
			restart();
		}
		
		if(itsLife<=0f){
			Player.life-=50;
			Instantiate(explosionPrefab, transform.position, transform.rotation);
			audio.Play();
			new WaitForSeconds(5);
			restart();
		}
		inputAny();
		
	}
	
	void OnParticleCollision(GameObject other) {
		itsLife-=5f;
		if(leftPressed &&  rightPressed){
			itsLife-=5f;
		}
		//print (itsLife);
	}
	
	private void restart(){
		itsLife = startingLife;
		transform.position = new Vector3(Random.Range(-2.5f, 2.5f), y, z);
		
	}
	
	
	public void inputAny(){
		
		leftPressed = InputHandler.leftPressed;
		rightPressed = InputHandler.rightPressed;
		
	}
	
}
