using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour {
    private GameObject cubeHolder;
    private GameObject[] L, R, C;
    private GameObject clickedObject;
    private int animation;
    private int animateFrames;
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
            //cubeHolder.transform.Rotate(new Vector3(0, 90, 0));
            animation = 1;
            

        }

        else if (direction == "right")
        {
            foreach (GameObject o1 in L[x].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }
            //cubeHolder.transform.Rotate(new Vector3(0, -90, 0));
            animation = 2;

        }

        else if (direction == "north")
        {

            foreach (GameObject o1 in R[y].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, 90));
            animation = 3;

        }
        else if (direction == "south")
        {

            foreach (GameObject o1 in R[y].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, -90));
            animation = 4;

        }
        StartCoroutine(rotator());




        //cubeHolder.transform.DetachChildren();


    }
    // Use this for initialization


    void Start () {
        animateFrames = 10;
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
        animation = 0;


    }

    // Update is called once per frame
    void Update () {
        //if (animation == 1 && cubeHolder.transform.rotation)
        //{
        //    cubeHolder.transform.Rotate(new Vector3(0, 90*Time.deltaTime, 0));
        //}
       // cubeHolder.transform.Rotate(new Vector3(10,0,0));
       
		
	}


    IEnumerator rotator()
    {
        Debug.Log("Dasd");
        for (int i = 0; i < 45; i++) // will run the loop 45 times
        {
            if(animation == 1) {
                cubeHolder.transform.Rotate(new Vector3(0, 2, 0));
            }
            if (animation == 2)
            {
                cubeHolder.transform.Rotate(new Vector3(0, -2, 0));
            }
            if (animation == 3)
            {
                cubeHolder.transform.Rotate(new Vector3(0, 0, 2));
            }
            if (animation == 4)
            {
                cubeHolder.transform.Rotate(new Vector3(0, 0, -2));
            }

            yield return new WaitForSeconds(0.0001f); // whatever time you want between loop iterations in seconds put in brackets so 1.0 would be on for 1 second then turn off 0.1 would be a tenth of a second
        }
        cubeHolder.transform.DetachChildren();
        yield break; // will stop the co-routine after all 45 iterations
    }
}
