using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaDoor : DioramaObject {

    public bool FlipDirection = true;
    public Vector3 Rotation = new Vector3(0,150,0);
    public float OpenSpeed = 1.0f;

    public bool IsOpening;
    private Vector3 _originalRotation;


	// Use this for initialization
	void Start ()
    {
        _originalRotation = this.transform.localRotation.eulerAngles;
        if (FlipDirection)
        {
            Rotation *= -1;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (IsOpening)
        {
            iTween.RotateTo(gameObject, iTween.Hash("rotation", _originalRotation + Rotation, "islocal", true, "time", OpenSpeed));
        }
        else
        {
            if (this.transform.localRotation.eulerAngles != _originalRotation)
            {
                iTween.RotateTo(gameObject, iTween.Hash("rotation", _originalRotation, "islocal", true, "time", OpenSpeed));
            }
        }
	}

    public override void Activate()
    {
        IsOpening = true;
    }

    public override void Deactivate()
    {
        IsOpening = false;
    }
}
