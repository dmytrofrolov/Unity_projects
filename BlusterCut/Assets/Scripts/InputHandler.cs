using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	public static bool leftPressed = false, rightPressed = true;
	private int left = 0, right = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		#if UNITY_ANDROID || UNITY_IOS
		left = 0;
		right = 0;
		foreach (Touch touch in Input.touches){
			
			if(touch.position.x < Screen.width*0.2f && touch.position.y < Screen.height * 0.5f)
			{
				
				left+=1;
				leftPressed = true;
			}
			
			if(touch.position.x > Screen.width*0.8f && touch.position.y < Screen.height * 0.5f)
			{
				right+=1;
				rightPressed = true;
			}
			
		}
		
		if(left==0)leftPressed = false;
		
		if(right==0)rightPressed = false;
		
		
		if(Input.touchCount == 0)
		{
			rightPressed = false;
			leftPressed = false;
		}
		
		#endif
		
		#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		KeyCode leftKey = KeyCode.LeftAlt;
		KeyCode rightKey = KeyCode.RightAlt;
		
		if(Input.GetKey(leftKey)) {
			leftPressed = true;
		}else leftPressed = false;
		
		if(Input.GetKey(rightKey)){
			rightPressed = true;
		}else rightPressed = false;
		#endif


	}
}
