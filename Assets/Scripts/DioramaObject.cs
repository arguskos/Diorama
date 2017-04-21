using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
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
    public SignObject Sign;
    public Transform SpawnPoint;

    private SoundManager _soundManager;


    private bool _activated = false;
    public bool Item = false;
    public static List<int> Symbols=new List<int>();
    public static int CurrentFound = 0;
    void Start()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        Symbols.Clear();
        for (int i = 0; i < 4; i++)
        {
            Symbols.Add(Random.Range(0,16));
        }
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!_activated)
            {
                if (Item)
                {
                    gameObject.SetActive(false);
                }
                if (DependentObject && DependentObject._activated || Contains && DependentObject == null)
                {

                    Activate();
                    var b = Instantiate(Sign, SpawnPoint.position, Quaternion.identity);
                    b.transform.LookAt(Camera.main.transform);
                    b.transform.Rotate(new Vector3(0, 180, 0));
                    b.transform.eulerAngles=new Vector3(0,b.transform.eulerAngles.y,0);
                    print(Symbols[CurrentFound]);
                    b.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Mathf.Floor(Symbols[CurrentFound] / 4) * 0.25f, Symbols[CurrentFound] % 4 * 0.25f));
                    CurrentFound++;
                }
                if (Contains)
                {

                }
                else
                {
                    Deactivate();
                }
            }
            _activated = true;
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
            if (!_activated)
            {
                if (Item)
                {
                    gameObject.SetActive(false);
                }
                if (DependentObject && DependentObject._activated || Contains && DependentObject== null)
                {
               
                    Activate();
                    var b = Instantiate(Sign, SpawnPoint.position, Quaternion.identity);
                    b.transform.LookAt(Camera.main.transform);
                    b.transform.Rotate(new Vector3(0, 180, 0));
                    print(Symbols[CurrentFound]);
                    b.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Mathf.Floor(Symbols[CurrentFound] / 4) * 0.25f, Symbols[CurrentFound] % 4 * 0.25f));
                    CurrentFound++;
                    _soundManager.PlaySound("Error");
                }
                if (Contains)
                {
                  
                }
                else
                {
                    Deactivate();
                }
            }
            _activated = true;

        }

    }
}
