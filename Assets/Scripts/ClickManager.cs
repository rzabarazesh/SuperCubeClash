using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour,IPointerClickHandler {
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
    private List<GameObject> findAdjacent(int face)
    {
        List<GameObject> adjacentTiles = new List<GameObject>();
        RaycastHit hit;
        switch (face)
        {
            // Y up
            case 2:

                if (Physics.Raycast(transform.position + new Vector3(0, 2, 1), new Vector3(0, -1, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }
                    

                if (Physics.Raycast(transform.position + new Vector3(0, 2, -1), new Vector3(0, -1, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                   
                }
                if (Physics.Raycast(transform.position + new Vector3(1, 2, 0), new Vector3(0, -1, 0), out hit, 100.0f))
                {
                   
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(-1, 2, 0), new Vector3(0, -1, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }
                break;
            //Y down
            case 6:

                if (Physics.Raycast(transform.position + new Vector3(0, -2, 1), new Vector3(0, 1, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                   
                }


                if (Physics.Raycast(transform.position + new Vector3(0, -2, -1), new Vector3(0, 1, 0), out hit, 100.0f))
                {
                   
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(1, -2, 0), new Vector3(0, 1, 0), out hit, 100.0f))
                {
                   
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(-1, -2, 0), new Vector3(0, 1, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }
                break;

            //Z UP
            case 4:
                if (Physics.Raycast(transform.position + new Vector3(1, 0, 2), new Vector3(0, 0, -1), out hit, 100.0f))
                {
                   
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }


                if (Physics.Raycast(transform.position + new Vector3(-1, 0, 2), new Vector3(0, 0, -1), out hit, 100.0f))
                {
                   
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(0, 1, 2), new Vector3(0, 0, -1), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(0, -1, 2), new Vector3(0, 0, -1), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }
                break;

            //Z UP
            case 1:
                if (Physics.Raycast(transform.position + new Vector3(1, 0, -2), new Vector3(0, 0, 1), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                   
                }


                if (Physics.Raycast(transform.position + new Vector3(-1, 0, -2), new Vector3(0, 0, 1), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(0, 1, -2), new Vector3(0, 0, 1), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(0, -1, -2), new Vector3(0, 0, 1), out hit, 100.0f))
                {
                   
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }
                break;

            //X UP
            case 5:
                if (Physics.Raycast(transform.position + new Vector3(2, 0, 1), new Vector3(-1, 0, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }


                if (Physics.Raycast(transform.position + new Vector3(2, 0, -1), new Vector3(-1, 0, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(2, 1, 0), new Vector3(-1, 0, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(2, -1, 0), new Vector3(-1, 0, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }
                break;
            //X Down
            case 3:
                if (Physics.Raycast(transform.position + new Vector3(-2, 0, 1), new Vector3(1, 0, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(-2, 0, -1), new Vector3(1, 0, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(-2, 1, 0), new Vector3(1, 0, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);
                    
                }

                if (Physics.Raycast(transform.position + new Vector3(-2, -1, 0), new Vector3(1, 0, 0), out hit, 100.0f))
                {
                    
                    adjacentTiles.Add(hit.collider.gameObject);

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
    private void unHighlightAll()
    {
        foreach (GameObject quad in cm.getquads())
        {

            quad.GetComponent<QuadManager>().mode = "idle";
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickObj;
        selectedObj = this.transform.gameObject;
        cm.setClickedObj(this.transform.gameObject);
        RaycastHit target;

        Ray ray_casting = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject selectedPiece = null;
        if (Physics.Raycast(ray_casting, out target))
        {
            clickObj = target.collider.gameObject;

            // if clicked on a piece
            if (clickObj.CompareTag("piece"))
            {
                unHighlightAll();
                cm.setSelectedPiece(clickObj);
                foreach (GameObject o in findAdjacent(findFace(clickObj.transform.parent.gameObject)))
                {
                    if (o.CompareTag("tile"))
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
                    else if (o.CompareTag("piece"))
                    {

                    }
                    else if (o.CompareTag("enemy"))
                    {
                        cm.addquad(o.transform.parent.gameObject);

                        if (o.transform.parent.gameObject.GetComponent<QuadManager>().mode != "hold")
                            o.transform.parent.gameObject.GetComponent<QuadManager>().mode = "hold";
                        else
                        {
                            o.transform.parent.gameObject.GetComponent<QuadManager>().mode = "idle";
                        }
                    }



                }
            }
            // if clicked on a empty tile
            else if (target.collider.GetType() == typeof(MeshCollider))
            {   //tile is idle
                if (clickObj.GetComponent<QuadManager>().mode == "idle")
                {
                    cm.setFace(findFace(target.collider.gameObject));

                }
                //tile is in moving mode
                else if (clickObj.GetComponent<QuadManager>().mode == "hold")
                {


                    cm.getSelectedPiece().transform.SetParent(clickObj.transform);

                    StartCoroutine(cm.MoveObject(cm.getSelectedPiece(), clickObj.transform.position, 1f));
                    //cm.getSelectedPiece().transform.position = clickObj.transform.position;

                }
                unHighlightAll();

                
            }
            else if (clickObj.CompareTag("selector"))
            {
               
            }

            if (true)
            {
                selectedPiece = target.collider.gameObject;
            }

        }


    }
}
