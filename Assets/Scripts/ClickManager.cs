using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {
    private CubeManager cm;
    public Material selectedMat;
    private Material beforeMat;
    // Use this for initialization
    private GameObject selectedObj;
	void Start () {
        selectedObj = null;
        cm = GameObject.Find("GameManager").GetComponent<CubeManager>();
    }
	
	// Update is called once per frame
	void Update () {

    }
    private void OnMouseDown()
    {

        selectedObj = this.transform.gameObject;       
        cm.setClickedObj(this.transform.gameObject);
        //foreach (Transform child in transform)
        //{
        //    beforeMat = child.GetComponent<Renderer>().material;
        //    child.GetComponent<Renderer>().material.SetColor( += 10.0f;

        //}

    }
    private void OnMouseUp()
    {
        //foreach (Transform child in transform)
        //{
           
        //    child.GetComponent<Renderer>().material = beforeMat;

        //}

    }

}
