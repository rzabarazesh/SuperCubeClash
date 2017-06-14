using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {
    private CubeManager cm;
    public Material selectedMat;
    private Material beforeMat;
    // Use this for initialization
    private GameObject selectedObj;

    //public Material material;
    //public Renderer rend;
    public Shader shader1;
    public Shader shader2;
    private bool selected = false;
   

    void Start () {
        selectedObj = null;
        cm = GameObject.Find("GameManager").GetComponent<CubeManager>();


         
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //rend.material = material;
        var shader1 = new Shader();
        var shader2 = new Shader();
        //var selectedMat = new Material(shader2);
    }
	
	// Update is called once per frame
	void Update () {

    }
    private void OnMouseDown()
    {

        selectedObj = this.transform.gameObject;       
        cm.setClickedObj(this.transform.gameObject);
        RaycastHit target;
        Ray ray_casting = Camera.main.ScreenPointToRay(Input.mousePosition);
        int face = -1;
        
        foreach (Transform child in selectedObj.transform)
        {
            if (Physics.Raycast(ray_casting, out target))
                if (target.collider.name == child.name)
                {
                    
                   
                    //selectedMat = target.collider.gameObject.GetComponent<Material>();
                    var rend = new Renderer();
                    rend = target.collider.GetComponent<Renderer>();
                    rend.enabled = true;
                    //rend.material = selectedMat;

                    
                    if (Input.GetMouseButtonDown(0))
                    {
                            if (selected)
                            {

                                rend.material.shader = shader2;
                                selected = false;
                            }
                            else
                            {
                                rend.material.shader = shader1;
                                selected = true;
                            }
                        
                        
                    }


                    // Debug massage
                    print("Got Side : " + child.name);
                    Debug.Log(child.name[6]);
                    face = child.name[6] - '0';
                    Debug.Log("face: " + face);
                    break;
                }
                else
                    Debug.Log("Touching nothing !");
        }

    }
    private void OnMouseUp()
    {
        //foreach (Transform child in transform)
        //{
           
        //    child.GetComponent<Renderer>().material = beforeMat;

        //}

    }

}
