using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {
    private GameManager cm;
    //public Material selectedMat;
    private Material beforeMat;
    private GameObject origin;
    private GameObject selectedObj;
    public GameObject selector;
    private List<GameObject> quadlist;
    
    void Start () {
        
        origin = GameObject.Find("GameManager");
        cm = GameObject.Find("GameManager").GetComponent<GameManager>();
        quadlist = cm.getquads();
        selectedObj = null;
    }
	
	// Update is called once per frame
	void Update () {

    }
    private List<GameObject> movePiece(int face)
    {
        List<GameObject> adjacentTiles = new List<GameObject>();
        RaycastHit hit;
        switch (face)
        {
            // Y up
            case 2:

                if (Physics.Raycast(transform.position + new Vector3(0, 2, 1), new Vector3(0, -1, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }
                    

                if (Physics.Raycast(transform.position + new Vector3(0, 2, -1), new Vector3(0, -1, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }
                if (Physics.Raycast(transform.position + new Vector3(1, 2, 0), new Vector3(0, -1, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(-1, 2, 0), new Vector3(0, -1, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }
                break;
            //Y down
            case 6:

                if (Physics.Raycast(transform.position + new Vector3(0, -2, 1), new Vector3(0, 1, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }


                if (Physics.Raycast(transform.position + new Vector3(0, -2, -1), new Vector3(0, 1, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(1, -2, 0), new Vector3(0, 1, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(-1, -2, 0), new Vector3(0, 1, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }
                break;

            //Z UP
            case 4:
                if (Physics.Raycast(transform.position + new Vector3(1, 0, 2), new Vector3(0, 0, -1), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }


                if (Physics.Raycast(transform.position + new Vector3(-1, 0, 2), new Vector3(0, 0, -1), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(0, 1, 2), new Vector3(0, 0, -1), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(0, -1, 2), new Vector3(0, 0, -1), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }
                break;

            //Z UP
            case 1:
                if (Physics.Raycast(transform.position + new Vector3(1, 0, -2), new Vector3(0, 0, 1), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }


                if (Physics.Raycast(transform.position + new Vector3(-1, 0, -2), new Vector3(0, 0, 1), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(0, 1, -2), new Vector3(0, 0, 1), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(0, -1, -2), new Vector3(0, 0, 1), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }
                break;

            //X UP
            case 5:
                if (Physics.Raycast(transform.position + new Vector3(2, 0, 1), new Vector3(-1, 0, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }


                if (Physics.Raycast(transform.position + new Vector3(2, 0, -1), new Vector3(-1, 0, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(2, 1, 0), new Vector3(-1, 0, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(2, -1, 0), new Vector3(-1, 0, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }
                break;
            //X Down
            case 3:
                if (Physics.Raycast(transform.position + new Vector3(-2, 0, 1), new Vector3(1, 0, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(-2, 0, -1), new Vector3(1, 0, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(-2, 1, 0), new Vector3(1, 0, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }

                if (Physics.Raycast(transform.position + new Vector3(-2, -1, 0), new Vector3(1, 0, 0), out hit, 100.0f))
                {
                    Debug.Log("Found an object - distance: " + hit.collider.name);
                    adjacentTiles.Add(hit.collider.gameObject);
                    //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }
                break;
        }
        return adjacentTiles;
    }
    private int findFace(GameObject quad)
    {
        Vector3 direction = quad.transform.position - origin.transform.position;
        float x = direction.x;
        float y = direction.y;
        float z = direction.z;
        if (y > 2 - 0.1 && y < 2 + 0.1) {
            return (2);
        }
        else if (y > -2 - 0.1 && y < -2 + 0.1) {
            return (6);
        }

        else if (z > 2 - 0.1 && z < 2 + 0.1) {
            return (4);
        }
        else if (z > -2 - 0.1 && z < -2 + 0.1) {
            return (1);
        }

        else if (x > 2 - 0.1 && x < 2 + 0.1) {
            return (5);
        }
        else if (x > -2 - 0.1 && x < -2 + 0.1) {
            return (3);
        }
        else { return (0);
        }
            



    }
    private void OnMouseDown()
    {

        selectedObj = this.transform.gameObject;
        cm.setClickedObj(this.transform.gameObject);
        RaycastHit target;
        
        Ray ray_casting = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject selectedPiece = null;
        if (Physics.Raycast(ray_casting, out target))
        {
            Debug.Log("Got  : " + target.collider.gameObject.tag);
            if (target.collider.gameObject.CompareTag("piece"))
            {

                cm.setSelectedPiece(target.collider.gameObject);
                foreach (GameObject o in movePiece(findFace(target.collider.gameObject.transform.parent.gameObject)))
                {   
                    
                    cm.addquad(o);
                    print(o.name);
                    if (o.GetComponent<QuadManager>().mode != "hold")
                        o.GetComponent<QuadManager>().mode = "hold";
                    else
                    {
                        o.GetComponent<QuadManager>().mode = "idle";
                    }
                   
                }
            }
            else if (target.collider.GetType() == typeof(MeshCollider))
            {
                if (target.collider.gameObject.GetComponent<QuadManager>().mode == "idle")
                {
                    cm.setFace(findFace(target.collider.gameObject));
                    foreach (GameObject quad in cm.getquads())
                    {

                        Debug.Log (quad.name);
                        quad.GetComponent<QuadManager>().mode = "idle";
                    }
                }
                else if (target.collider.gameObject.GetComponent<QuadManager>().mode == "hold")
                {
                    
                    cm.getSelectedPiece().transform.SetParent(target.collider.gameObject.transform);
                    cm.getSelectedPiece().transform.position = target.collider.gameObject.transform.position;
                }
                
                
                Debug.Log("yoo");
            }
            else if(target.collider.gameObject.CompareTag("selector"))
            {
                Debug.Log("yeee");
            }
            
            if (true)
            {
                selectedPiece = target.collider.gameObject;
            }
               
        }
        
        
        

    }
 

}
