using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagController : MonoBehaviour {
    public GameObject winPanel;
    public int q1;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        winPanel.SetActive(true);
    }

}
