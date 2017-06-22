using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadManager : MonoBehaviour {
    public string mode;
    // Use this for initialization
    void Start () {
        GetComponent<cakeslice.Outline>().enabled = false;
        mode = "idle";

    }
	
	// Update is called once per frame
	void Update () {
        if (mode == "selected")
        {
            GetComponent<cakeslice.Outline>().enabled = true;
            GetComponent<cakeslice.Outline>().color = 2;
            
        }
        if (mode == "hold")
        {
            GetComponent<cakeslice.Outline>().enabled = true;
            GetComponent<cakeslice.Outline>().color = 1;
            
        }
        if (mode == "enemy")
        {
            GetComponent<cakeslice.Outline>().enabled = true;
            GetComponent<cakeslice.Outline>().color = 0;
            
        }
        if (mode == "idle")
        {
            GetComponent<cakeslice.Outline>().enabled = false;
        }
	}
}
