using UnityEngine;
using System.Collections;

public class loose : MonoBehaviour {


	public Font gameFont;
	public Texture2D toMainButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI(){

		GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
		labelStyle.font = gameFont;	
		int fontSize = Screen.height / 25;
		labelStyle.fontSize = fontSize;
		labelStyle.normal.textColor = new Color32(63, 121, 130, 255);
		labelStyle.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(Screen.width * 0.05f, Screen.height * 0.3f, Screen.width * 0.9f, Screen.height*0.2f), "HighScore: "+StaticInfo.scores.ToString(),labelStyle);


		GUI.skin.button.normal.background = toMainButton;
		GUI.skin.button.hover.background = toMainButton;
		GUI.skin.button.active.background = toMainButton;
		if(GUI.Button(new Rect(Screen.width * 0.35f, Screen.height*0.5f, Screen.width * 0.3f, Screen.width * 0.3f), ""))
			Application.LoadLevel(0);

		
	}	

}
