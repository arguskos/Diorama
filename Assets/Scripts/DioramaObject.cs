using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaObject : MonoBehaviour
{

    // Use this for initialization
    public bool Contains;
    public bool Interactale;
    private Animator _anim;
    private int _JumpHash = Animator.StringToHash("Open");
    private int _FellHash = Animator.StringToHash("Hint");
    public DioramaObject DependentObject;
    private bool _activated = false;
    public bool Item = false;

    void Start()
    {

        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Contains)
                Activate();
            else
            {
                Deactivate();
            }
        }

    }

    public virtual void Activate()
    {
        _anim.SetTrigger(_JumpHash);
    }

    public virtual void Deactivate()
    {
        _anim.SetTrigger(_FellHash);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Index")
        {
            _activated = true;
            if (Item)
            {
                gameObject.SetActive(false);
            }
            if (DependentObject && DependentObject._activated)
                Activate();

            else if (Contains)
                Activate();
            else
            {
                Deactivate();
            }
        }
    }
}
