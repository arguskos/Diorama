using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignObject : MonoBehaviour {

    private SoundManager _soundManager;

    // Use this for initialization
    void Start ()
	{
        //Get soundmanager
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _soundManager.PlaySound("Progress_001");

        //iTween.Hash("x", 3, "time", 4, "delay", 1, "onupdate", "myUpdateFunction", "looptype", iTween.LoopType.pingPong));
        iTween.MoveAdd(this.gameObject, iTween.Hash("y", 0.0125f, "time", 1, "looptype", iTween.LoopType.pingPong));
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.LookAt(Camera.main.transform);
        this.transform.Rotate(new Vector3(0, 180, 0));
        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
    }

   
}
