using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("turnL"))
        {
            Debug.Log("turnl");
        }
        if (Input.GetButton("turnR"))
        {
            Debug.Log("turnr");
        }
        if (Input.GetButton("extraBtn"))
        {
            Debug.Log("extr");
        }
        if (Input.GetButton("dipl1"))
        {
            Debug.Log("1");
        }
        if (Input.GetButton("dipl2"))
        {
            Debug.Log("2");
        }
        if (Input.GetButton("dipl3"))
        {
            Debug.Log("3");
        }
        if (Input.GetButton("dipl4"))
        {
            Debug.Log("4");
        }
        if (Input.GetButton("dipl5"))
        {
            Debug.Log("5");
        }
        if (Input.GetButton("dipl6"))
        {
            Debug.Log("6");
        }

		
	}
}
