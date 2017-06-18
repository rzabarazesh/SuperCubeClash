using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        RaycastHit target;
        Ray ray_casting = Camera.main.ScreenPointToRay(Input.mousePosition);
        int face = -1;
            if (Physics.Raycast(ray_casting, out target))
                if (target.collider.name == name)
                {
                    print("Got  : " + name);
                    Debug.Log(name);
                    
                }
                else
                    Debug.Log("Touching nothing !");
        Vector3 positionBuffer = new Vector3(1,0,0);
        RaycastHit hit;
        if (Physics.Raycast(transform.position + positionBuffer, new Vector3(0,-1,-1), out hit, 100.0f)) {
            print("Found an object - distance: " + hit.collider.name);
        }
            
   
    }
}
