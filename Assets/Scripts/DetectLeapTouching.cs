using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLeapTouching : MonoBehaviour {

    public GameObject[] ActivatableObjects;


    private GameObject _indexFinger;
    private Vector3 _indexFingerPos;

	// Use this for initialization
	void Start ()
    {
        _indexFinger = GameObject.FindGameObjectWithTag("DioramaManager").GetComponent<DioramaManager>().IndexFinger;

    }

    // Update is called once per frame
    void Update () {

        _indexFingerPos = _indexFinger.transform.position;

        if (this.GetComponent<BoxCollider>().bounds.Contains(_indexFingerPos))
        {
            for (int i = 0; i < ActivatableObjects.Length; i++)
            {
                ActivatableObjects[i].GetComponent<DioramaObject>().Activate();
            }
        }
        else
        {
            for (int i = 0; i < ActivatableObjects.Length; i++)
            {
                ActivatableObjects[i].GetComponent<DioramaObject>().Deactivate();
            }
        }
	}
}
