using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidorScript : MonoBehaviour {
    private List<GameObject> inside;
	// Use this for initialization
	void Start () {
        inside = new List<GameObject>();
	}
    public List<GameObject> getinside()
    {
        return this.inside;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(name);
        //foreach (GameObject g in getinside())
        //{

        //    Debug.Log(g.name);
        //}
        //Debug.Log("=======");
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.GetType());
        if(other.GetType() == typeof(BoxCollider))
        {
            inside.Add(other.transform.gameObject);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        inside.Remove(other.transform.gameObject);
    }
    

}
