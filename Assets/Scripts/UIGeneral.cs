using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
public class UIGeneral : MonoBehaviour
{

    public List<Image> InputImages;
    public int CurrentSelection; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetActive()
    {
        
    }
    public void SelectionUp()
    {
        CurrentSelection++;
        CurrentSelection %= 4;
    }

    public void SelectionDown()
    {
        CurrentSelection--;
        if (CurrentSelection < 0)
        {
            CurrentSelection = 3;
        }
    }
}
