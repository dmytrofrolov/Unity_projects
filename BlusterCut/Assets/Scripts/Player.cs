using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

		public float playerSpeed = 1;
		public GameObject leftLaser;
		public GameObject rightLaser;
		public GameObject bigLaserL, bigLaserR;
		public Texture2D pauseButton;
		private bool rightPressed = false, leftPressed = false;
		public static int scores = 0;
		public static float life = 100.0f;
		public static float mana = 0.0f;
		public static float speedCoef = 1.00f;
		public Font gameFont;

		// Use this for initialization
		void Start ()
		{
		leftLaser.particleSystem.enableEmission=false;
		rightLaser.particleSystem.enableEmission=false;
		}
			
		void OnGUI(){
		/// ________   BOX WITH LIFE STARTS
			GUIStyle lifeStyle = new GUIStyle(); 
			Texture2D lifeTexture = new Texture2D(1, 1);
			for (int y = 0; y < lifeTexture.height; ++y) 
			{ 
				for (int x = 0; x < lifeTexture.width; ++x) 
				{ 
					Color color = new Color(135.0f/256f, 183f/256f, 105f/256f); 
					lifeTexture.SetPixel(x, y, color); 
				} 
			} 
			lifeTexture.Apply();
			lifeStyle.normal.background = lifeTexture;
			if(Player.mana<=0)
				Player.life -= GameSettings.decreasingPlayerLife;
			GUI.Box(new Rect(Screen.width*0.06f, Screen.height*0.05f, Screen.width*0.54f*Player.life/100, Screen.height*0.08f), new GUIContent(""), lifeStyle);
		/// ________   BOX WITH LIFE ENDS

		/// ________   BOX WITH MANA STARTS
			if(Player.mana>0){
				lifeStyle = new GUIStyle(); 
				lifeTexture = new Texture2D(1, 1);
				for (int y = 0; y < lifeTexture.height; ++y) 
				{ 
					for (int x = 0; x < lifeTexture.width; ++x) 
					{ 
						Color color = new Color(135.0f/256f, 103f/256f, 185f/256f); 
						lifeTexture.SetPixel(x, y, color); 
					} 
				} 
				lifeTexture.Apply();
				lifeStyle.normal.background = lifeTexture;
				Player.mana -=GameSettings.decreasingMana;
				GUI.Box(new Rect(Screen.width*0.06f, Screen.height*0.05f, Screen.width*0.54f*Player.mana/100, Screen.height*0.08f), new GUIContent(""), lifeStyle);
			}
		/// ________   BOX WITH MANA ENDS


			GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
			labelStyle.font = gameFont;	
			int fontSize = Screen.height / 25;
			labelStyle.fontSize = fontSize;
			GUI.Label(new Rect(10, 10, Screen.width * 0.9f, Screen.height*0.1f), "Scores: "+scores.ToString(),labelStyle);

			GUI.skin.button.normal.background = pauseButton;
			GUI.skin.button.hover.background = pauseButton;
			GUI.skin.button.active.background = pauseButton;
			if(GUI.Button(new Rect(Screen.width * 0.80f, Screen.height*0.05f, Screen.width * 0.1f, Screen.width*0.1f), " "))
				Application.LoadLevel(0);

		}	

		// Update is called once per frame
		void Update ()
		{

		if(life<=0)
		{
			life=0;
			if(scores>StaticInfo.scores)
			{
				StaticInfo.scores=scores;
				PlayerPrefs.SetInt("HighScore",scores );
			}
			Application.LoadLevel(2);
		}

		inputAny();

		if(leftPressed || rightPressed) audio.Play();
		else audio.Pause();

		//only left
		if(leftPressed && !rightPressed) 
			leftLaser.particleSystem.enableEmission = true;
		else 
			leftLaser.particleSystem.enableEmission = false;

		//only right
		if(rightPressed && !leftPressed) 
			rightLaser.particleSystem.enableEmission = true;
		else 
			rightLaser.particleSystem.enableEmission = false;

		//both left and right
		if(leftPressed && rightPressed )
		{
			bigLaserL.particleSystem.enableEmission = true;
			bigLaserR.particleSystem.enableEmission = true;
		}
		else //none of left or right
		{
			bigLaserL.particleSystem.enableEmission = false;
			bigLaserR.particleSystem.enableEmission = false;
		}



		//Amount to move
		//float amtToMove = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;

		//move the player
		//transform.Translate(Vector3.right * amtToMove);

		//Amount to move
		//amtToMove = Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;
		
		//move the player
		//transform.Translate(Vector3.up * amtToMove);

		//wrap
		//if(transform.position.x<-4.3f)
		//	transform.position = new Vector3(4.3f, transform.position.y, transform.position.z);
		//if(transform.position.x>4.3f)
		//	transform.position = new Vector3(-4.3f, transform.position.y, transform.position.z);

	}

	public void inputAny(){
		leftPressed = InputHandler.leftPressed;
		rightPressed = InputHandler.rightPressed;
	}
}

