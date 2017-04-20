using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class nfc : MonoBehaviour {

    public int baud;
    public string com;

    new SerialPort nfcScan;
	// Use this for initialization
	void Start () {
        nfcScan = new SerialPort(com, baud);
        nfcScan.ReadTimeout = 25;
        nfcScan.Open();
        nfcScan.Write("a");
	}
	
	// Update is called once per frame
	void Update () {
        if (nfcScan.ReadLine() == "1")
        {
            Debug.Log("klakzmalknzjk");
            Application.LoadLevel(1);
        }
	}
}
