using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public float itsLife = GameSettings.enemyLife;
	public float currentSpeed;
	public float yShiftCoef;
	public bool isDynamite = false;
	public bool isGiveMana = false;
	public bool isChargable = false;
	public GameObject chargeLevel;
	public GameObject explosionPrefab;
	private bool rightPressed = false, leftPressed = false;
	private float particleLifeKill = GameSettings.particleLifeKill;
	private float minSpeed = GameSettings.minSpeed;
	private float maxSpeed = GameSettings.maxSpeed;



	private float x, y, z;


	// Use this for initialization
	void Start () {
		restart();

	}
		
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;
		float amtToMove = currentSpeed * Time.deltaTime * Player.speedCoef;
		transform.Translate(Vector3.down * amtToMove, Space.World);

		if(transform.position.y < -7f)
		{
			Destroy(gameObject);
			GameSettings.enemysOnScreen--;
			GameSettings.createNewEnemy();
			Player.speedCoef+=0.01f;
			GameSettings.decreasingPlayerLife += 0.0005f;
			GameSettings.decreasingMana += 0.0005f;
		}

		inputAny();

	}

	void OnCollisionEnter(Collision col){
		if(!isGiveMana){
			Destroy(gameObject);
			GameSettings.enemysOnScreen--;
			GameSettings.createNewEnemy();
		}
	}

	void OnParticleCollision(GameObject other) {
		if(isDynamite){
			isDynamite=false;
			if(Player.mana < 1)
				Player.life*=0.5f;
			//blowUp();
			Instantiate(explosionPrefab, transform.position, transform.rotation);
			audio.Play();
			GameSettings.enemysOnScreen--;
			Destroy(gameObject);
			GameSettings.createNewEnemy();
			return;
		}
		if(isGiveMana){
			if(Player.mana<100 && Player.mana<Player.life){
				Player.mana+=GameSettings.increasingMana;}
		}else{
			if(Player.life<100)
				Player.life+=GameSettings.increasingPlayerLife;
		}
		if(itsLife>=0){
			Player.scores+=GameSettings.increasingScores;
			itsLife-=particleLifeKill;
			if(leftPressed &&  rightPressed){
				itsLife-=particleLifeKill;
			}
			if(isChargable){
				chargeLevel.transform.localScale = new Vector3(1.0f,itsLife/GameSettings.enemyLife,1);
				chargeLevel.transform.localPosition = new Vector3(0, -4.15f+0.04f*itsLife, 0.1f);
			}
		}
	}

	private void restart(){
		if(isGiveMana){
			y = Random.Range(50f, 55f);
		}else{
			y = transform.position.y;
		}
		z = -10f;

		x = transform.position.x;

		//currentSpeed = Random.Range(minSpeed, maxSpeed);
		itsLife = GameSettings.enemyLife;
		transform.position = new Vector3(x, y, z);
		if(isChargable){
			chargeLevel.transform.localScale = new Vector3(1.0f,itsLife/GameSettings.enemyLife,1);
			chargeLevel.transform.localPosition = new Vector3(0, -0.15f, 0.1f);
		}

	}


	public void inputAny(){
		leftPressed = InputHandler.leftPressed;
		rightPressed = InputHandler.rightPressed;
	}

	public void blowUp(){
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		audio.Play();
		GameSettings.enemysOnScreen--;
		Destroy(gameObject);
		GameSettings.createNewEnemy();

	}

}
