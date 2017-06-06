using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour {
    private GameObject cubeHolder;
    private GameObject[] L, R, C;
    private GameObject clickedObject;
    public void setClickedObj(GameObject obj)
    {
        clickedObject = obj;
    }


    public void rotateBlocks(string direction)
    {
        cubeHolder.transform.rotation = Quaternion.identity ;
        cubeHolder.transform.DetachChildren();
        int x = 0, y = 0, z = 0;

        for (int i = 0; i < 4; i++)
        {
            foreach (GameObject o1 in L[i].GetComponent<collidorScript>().getinside())
            {
                if (o1 == clickedObject)
                {
                    x = i;
                    break;
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            foreach (GameObject o1 in C[i].GetComponent<collidorScript>().getinside())
            {
                if (o1 == clickedObject)
                {
                    z = i;
                    break;
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            foreach (GameObject o1 in R[i].GetComponent<collidorScript>().getinside())
            {
                if (o1 == clickedObject)
                {
                    y = i;
                    break;
                }
            }
        }


        if (direction == "left")
        {
            foreach (GameObject o1 in L[x].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }
            cubeHolder.transform.Rotate(new Vector3(0, 90, 0));

        }

        else if (direction == "right")
        {
            foreach (GameObject o1 in L[x].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }
            cubeHolder.transform.Rotate(new Vector3(0, -90, 0));

        }

        else if (direction == "north")
        {

            foreach (GameObject o1 in R[y].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }

            cubeHolder.transform.Rotate(new Vector3(0, 0, 90));

        }
        else if (direction == "south")
        {

            foreach (GameObject o1 in R[y].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }

            cubeHolder.transform.Rotate(new Vector3(0, 0, -90));

        }





        cubeHolder.transform.DetachChildren();


    }
    // Use this for initialization


    void Start () {
        L = new GameObject[4];
        R = new GameObject[4];
        C = new GameObject[4];
        
        L[0] = GameObject.Find("L1");
        L[1] = GameObject.Find("L2");
        L[2] = GameObject.Find("L3");
        L[3] = GameObject.Find("L4");

        C[0] = GameObject.Find("C1");
        C[1] = GameObject.Find("C2");
        C[2] = GameObject.Find("C3");
        C[3] = GameObject.Find("C4");

        R[0] = GameObject.Find("R1");
        R[1] = GameObject.Find("R2");
        R[2] = GameObject.Find("R3");
        R[3] = GameObject.Find("R4");
        

        cubeHolder = GameObject.Find("CubeHolder");


    }

    // Update is called once per frame
    void Update () {
       // cubeHolder.transform.Rotate(new Vector3(10,0,0));
		
	}
}
