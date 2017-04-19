using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaManager : MonoBehaviour {

    public GameObject[] Houses;
    public int CurrentHouse;
    public float MoveSpeed = 0.5f;
    public GameObject IndexFinger;

    private Vector3[] _houseRotations = new Vector3[10];

    // Use this for initialization
    void Start () {

        //Set each house to correct position
        for (int i = 0; i < Houses.Length; i++)
        {
            var startPos = new Vector3(i,0,0);
            Houses[i].transform.position = startPos;
            _houseRotations[i] = Houses[i].transform.rotation.eulerAngles;
        }

        CurrentHouse = 0;

    }
	
	// Update is called once per frame
	void Update () {
        //Keys
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CurrentHouse++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CurrentHouse--;
        }

        var rotamount = new Vector3(0, 45, 0);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _houseRotations[CurrentHouse] += rotamount;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _houseRotations[CurrentHouse] -= rotamount;
        }

        //Movement of houses
        for (int i = 0; i < Houses.Length; i++)
        {
            if ( _houseRotations[i].y >= 360 || _houseRotations[i].y <= -360 )
            {
                _houseRotations[i].y = 0;
            }
            iTween.MoveTo(Houses[i], new Vector3((i - CurrentHouse)*100.0f, 0, 0), MoveSpeed);
            iTween.RotateTo(Houses[i], _houseRotations[i], MoveSpeed);
        }
    }

    public void SetCurrentHouse(int current)
    {
        CurrentHouse = current;
    }
}
