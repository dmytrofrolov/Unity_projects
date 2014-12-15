using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    // Speed to be modified in the Inspector
    public float startedSpeed = 1.05f;
    public bool gameStarted = false;
    private float speed = 1.05f;
    private int score = 0;

    void newGame(){
        score = 0;
        speed = startedSpeed;
        float x = Random.value;
        float koef = 1.0f;
        if (x>0.5f) koef=-1.0f;
        rigidbody2D.velocity = new Vector2(Random.Range(1.0f,2.0f)*koef, Random.Range(1.0f,2.0f)*koef);
        rigidbody2D.position = new Vector2(0, 0);
    }

    void Start() {
    	Input.location.Start();
    }

   	void Update () {
        if (gameStarted==false)
        {
            Touch touch;
            if (Input.touchCount > 0) {
                touch = Input.GetTouch(0);
                if(touch.position[1] > Screen.height*0.4f && touch.position[1]<Screen.height*0.7f) gameStarted = true;
            }

            if(Input.GetKey(KeyCode.Space)) gameStarted = true;
            if (gameStarted==true) newGame();
        }

	}


    void OnGUI()
	{



        if (Input.location.status == LocationServiceStatus.Failed) {
            print("Unable to determine device location");
            return;
        } else
       		GUI.Label(new Rect(Screen.height*0.3f,Screen.height*0.27f,200,100),"Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);



		GUI.Label(new Rect(Screen.height*0.3f,Screen.height*0.17f,100,100),"Best score: "+score.ToString());

        //windows
        if (gameStarted==false) GUI.Label(new Rect(Screen.height*0.3f,Screen.height*0.33f,100,100),"To start press space key!");
        
        //android
        //if (gameStarted==false) GUI.Label(new Rect(105,155,100,100),"To start touch here!");
	}

    void OnCollisionEnter2D(Collision2D col) {
    // Hit the Racket?
    if (col.gameObject.name == "RacketLeft" || col.gameObject.name == "RacketRight") {
        score++;
        rigidbody2D.velocity *=speed;

    }

    if (col.gameObject.name == "quart_circle") {
        gameStarted=false;
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.position = new Vector2(0, 0);
    }



	}
}
