using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
    public GameObject battleCanvas;
    public int background;
    private GameManager gm;
    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //mainCanvas.SetActive(false);
        Instantiate(battleCanvas);
        if (gm.isPowerUp())
        {
            battleCanvas.GetComponent<battle>().battle_start(true, background, 1, 200, 100, 1, 100, 100);
        }
        else {
            battleCanvas.GetComponent<battle>().battle_start(true, background, 1, 100, 60, 1, 100, 100);
        }
        
        battleCanvas.GetComponent<battle>().setPlayerObjects(other.gameObject, this.gameObject);

    }

}
