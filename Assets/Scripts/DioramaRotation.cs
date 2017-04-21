using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaRotation : MonoBehaviour {


    public float MoveSpeed = 0.5f;
    private GameObject _level;
    private Vector3 _levelRotation;
    private SoundManager _soundManager;

    // Use this for initialization
    void Start ()
    {
        //Get soundmanager
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
            
        //Set Level to this
        _level = this.gameObject;

        //Set Level to correct position
        _levelRotation = _level.transform.rotation.eulerAngles;
    }

	
	// Update is called once per frame
	void Update () {

        //Set Amount of rotation to 45 degrees
        var rotamount = new Vector3(0, 45, 0);


        //On Button Up
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("turnL"))
        {
            _soundManager.PlaySound("SelectionInGame");
            _levelRotation += rotamount;    
        }

        //On Button Down
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetButtonDown("turnR"))
        {
            _soundManager.PlaySound("SelectionInGame");
            _levelRotation -= rotamount;
        }

        //Tween Rotation of Level
        if (_levelRotation.y >= 360 || _levelRotation.y <= -360 )
        {
            _levelRotation.y = 0;
        }
        iTween.RotateTo(_level, _levelRotation, MoveSpeed);
    }
}
