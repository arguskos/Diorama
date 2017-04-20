using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignObject : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

        //iTween.Hash("x", 3, "time", 4, "delay", 1, "onupdate", "myUpdateFunction", "looptype", iTween.LoopType.pingPong));
        iTween.MoveAdd(this.gameObject, iTween.Hash("y", 0.05f, "time", 1, "looptype", iTween.LoopType.pingPong));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
