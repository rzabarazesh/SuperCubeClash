using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
    public GameObject battleCanvas;
    private GameObject mainCanvas;
    // Use this for initialization
    void Start () {
        mainCanvas = GameObject.Find("canvas");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //mainCanvas.SetActive(false);
        Instantiate(battleCanvas);
        
        battleCanvas.GetComponent<battle>().setPlayerObjects(other.gameObject, this.gameObject);

    }
}
