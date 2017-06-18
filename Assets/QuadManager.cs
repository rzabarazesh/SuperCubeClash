using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadManager : MonoBehaviour {
    public string mode;
    private Material mat;
    private Color col;
    // Use this for initialization
    void Start () {
        GetComponent<cakeslice.Outline>().enabled = false;
        mode = "idle";
        mat = GetComponent<Renderer>().material;
        col = GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (mode == "hold")
        {
            //GetComponent<Renderer>().material.color = Color.yellow;
            GetComponent<cakeslice.Outline>().enabled = true;
        }
        if(mode == "idle")
        {
            GetComponent<cakeslice.Outline>().enabled = false;
        }
	}
}
