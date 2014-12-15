using UnityEngine;
using System.Collections;


public class MoveRacket : MonoBehaviour {

    // up and down keys (to be set in the Inspector)

    public KeyCode up;
    public KeyCode down;
    private float minY = Screen.width*0.0f, maxY = Screen.width*0.4f;
    private float angleStep = 1.9143f, moveStep = 0.1f;


    void Start(){

    }

    void Update(){


    }

    void FixedUpdate () {

    	foreach (Touch touch in Input.touches) {
	    	if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
	    		if(touch.position[1]>minY && touch.position[1]<maxY)
	    		{
		    		if (touch.position[0]>400 ){
			    		transform.Translate(new Vector2(0.0f, moveStep));
                        transform.Rotate(new Vector3(0,0,angleStep));
                    }
			    	else{
			    		transform.Translate(new Vector2(0.0f, -moveStep));
                        transform.Rotate(new Vector3(0,0,-angleStep));
                    }
			    }
	    }

        // up key pressed?

        if (Input.GetKey(up)) {

            transform.Translate(new Vector2(0.0f, moveStep));
            transform.Rotate(new Vector3(0,0,angleStep));

        }



        // down key pressed?

        if (Input.GetKey(down)) {

            transform.Translate(new Vector2(0.0f, -moveStep));
            transform.Rotate(new Vector3(0,0,-angleStep));


        }

    }

}