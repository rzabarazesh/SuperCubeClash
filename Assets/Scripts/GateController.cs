using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {
    private bool openning;
	// Use this for initialization
    public void open()
    {
        openning = true;
    }
	void Start () {
        openning = false;
	}
    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update () {
        if (openning)
        {
            
            foreach (Transform c in transform) {
                if (c.gameObject.CompareTag("Gate_Moving"))
                {
                    transform.parent.gameObject.tag = "tile";
                    c.transform.position = new Vector3(0, 0, 0);
                    openning = false;
                }
            }

            
        }
	}
}
