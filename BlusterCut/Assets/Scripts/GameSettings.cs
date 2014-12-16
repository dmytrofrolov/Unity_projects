using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {
	public static float enemyLife = 100.0f;
	public static float particleLifeKill = 1.0f;
	public static float increasingPlayerLife = 1.0f;
	public static float increasingMana = 1.0f;
	public static float decreasingPlayerLife = 0.02f;
	public static float decreasingMana = 0.022f;
	public static int increasingScores = 1;
	public static float maxSpeed = 3.0f;
	public static float minSpeed = 2.0f;
	public GameObject enemyCasual;
	public GameObject enemyGivesMana;
	public GameObject enemyDynamite;
	public GameObject enemyFat;
	private static GameObject staticEnemyCasual;
	private static GameObject staticEnemyFat;
	private static GameObject staticEnemyMana;
	private static GameObject staticDynamite;
	private static GameObject newEnemy;
	public static int enemysOnScreen = 0;


	public static void setNew(){
		GameSettings.enemyLife = 100.0f;
		GameSettings.particleLifeKill = 1.0f;
		GameSettings.increasingPlayerLife = 1.0f;
		GameSettings.increasingMana = 1.0f;
		GameSettings.decreasingPlayerLife = 0.01f;
		GameSettings.decreasingMana = 0.011f;
		GameSettings.increasingScores = 1;
		GameSettings.maxSpeed = 3.0f;
		GameSettings.minSpeed = 2.0f;
	}

	void Awake(){
		staticEnemyCasual = enemyCasual;
		staticEnemyFat = enemyFat;
		staticEnemyMana = enemyGivesMana;
		staticDynamite = enemyDynamite;
		//GameSettings.createNewEnemy();
	}


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void createNewEnemy(){
		if(enemysOnScreen<5){
			int rand = Random.Range(1,100);
			float x = Random.Range(-2.3f, 2.3f);
			if(rand>0 && rand<6)newEnemy=staticEnemyMana;
			else if(rand>5 && rand<26)newEnemy=staticDynamite;
			else if(rand>25 && rand <36)newEnemy=staticEnemyFat;
			else newEnemy=staticEnemyCasual;
			Instantiate(newEnemy, new Vector3(x, 13, -10), Quaternion.identity);
			enemysOnScreen++;
		}
	}
}
