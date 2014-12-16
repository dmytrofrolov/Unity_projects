using UnityEngine;
using System.Collections;

public class mainmenu : MonoBehaviour {

	public Texture2D shareButton;
	public Texture2D optionsButton;
	public Texture2D startButton;
	public Font gameFont;




	// Use this for initialization
	void Start () {
		if(!PlayerPrefs.HasKey("HighScore")){
			PlayerPrefs.SetInt("HighScore",0);
		}
		StaticInfo.scores = PlayerPrefs.GetInt("HighScore");
		Application.targetFrameRate = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		GUI.skin.button.normal.background = shareButton;
		GUI.skin.button.hover.background = shareButton;
		GUI.skin.button.active.background = shareButton;
		if(GUI.Button(new Rect(Screen.width * 0.2f, Screen.height*0.25f, Screen.width * 0.6f, Screen.height*0.15f), ""))
		{
			string facebookshare = "https://www.facebook.com/sharer/sharer.php?u=qbxdev.com";
			Application.OpenURL(facebookshare);
		}

		GUI.skin.button.normal.background = optionsButton;
		GUI.skin.button.hover.background = optionsButton;
		GUI.skin.button.active.background = optionsButton;
		if(GUI.Button(new Rect(Screen.width * 0.2f, Screen.height*0.45f, Screen.width * 0.6f, Screen.height*0.15f), ""))
		{
			//audio.Play();
			//Application.Quit();
		}

		GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
		labelStyle.font = gameFont;	
		int fontSize = Screen.height / 25;
		labelStyle.fontSize = fontSize;
		labelStyle.normal.textColor = new Color32(63, 121, 130, 255);
		labelStyle.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(Screen.width * 0.15f, Screen.height*0.67f, Screen.width * 0.7f, Screen.height*0.15f), "Highscore: "+StaticInfo.scores.ToString(), labelStyle);

		GUI.skin.button.normal.background = startButton;
		GUI.skin.button.hover.background = startButton;
		GUI.skin.button.active.background = startButton;
		if(GUI.Button(new Rect(Screen.width * 0.0f, Screen.height*0.85f, Screen.width * 1.0f, Screen.height*0.15f), ""))
		{
			audio.Play();
			Player.speedCoef = 1.0f;
			Application.LoadLevel(1);
			Player.life = 100;
			Player.scores = 0;
			GameSettings.setNew();
		}
	}	
}
