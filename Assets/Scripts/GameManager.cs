using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private GameObject cubeHolder;
    private GameObject[] L, R, C;
    private GameObject clickedObject;
    private GameObject selectedPiece;
    private List<GameObject> enemyList;
    private int animation;
    private int animateFrames;
    public List<GameObject> changedQuads;
    public GameObject WinCanvas;
    private int face;
    private bool gameFinished;
    public void setClickedObj(GameObject obj)
    {
        clickedObject = obj;
    }
    public void clearQuads()
    {
        changedQuads.Clear();
    }

    public void setFace(int f)
    {
        face = f;
    }
    public GameObject getSelectedPiece()
    {
       return selectedPiece;
    }
    public void setSelectedPiece(GameObject p)
    {
        selectedPiece = p;
    }
    public List<GameObject> getquads()
    {
        return changedQuads;
    }
    public void addquad(GameObject q)
    {
        if (!changedQuads.Contains(q))
        {
            changedQuads.Add(q);
        }
    }


    public void rotateBlocks(string direction)
    {
        //---unhighlight everything
        foreach (GameObject quad in getquads())
        {
            quad.GetComponent<QuadManager>().mode = "idle";
            
        }
        clearQuads();
        //---
        cubeHolder.transform.rotation = Quaternion.identity;
        cubeHolder.transform.DetachChildren();
        int x = 0, y = 0, z = 0;

        for (int i = 0; i < 4; i++)
        {
            foreach (GameObject o1 in L[i].GetComponent<collidorScript>().getinside())
            {
                if (o1.name == clickedObject.name)
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
                if (o1.name == clickedObject.name)
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
                if (o1.name == clickedObject.name)
                {
                    y = i;
                    break;
                }
            }
        }
        Debug.Log("Face: " + face);
        int c = 0;
        switch (face)
        {
            case 2:
                if (direction == "left")
                    direction = "L";
                else if (direction == "right")
                    direction = "R";
                else if (direction == "L")
                    direction = "right";
                else if (direction == "R")
                    direction = "left";
                break;
            case 3:
                if (direction == "north")
                    direction = "R";
                else if (direction == "south")
                    direction = "L";
                else if (direction == "L")
                    direction = "north";
                else if (direction == "R")
                    direction = "south";
                break;
            case 4:
                if (direction == "north")
                    direction = "south";
                else if (direction == "south")
                    direction = "north";
                else if (direction == "L")
                    direction = "R";
                else if (direction == "R")
                    direction = "L";
                break;
            case 5:
                if (direction == "north")
                    direction = "L";
                else if (direction == "south")
                    direction = "R";
                else if (direction == "L")
                    direction = "south";
                else if (direction == "R")
                    direction = "north";
                break;
            case 6:
                if (direction == "left")
                    direction = "R";
                else if (direction == "right")
                    direction = "L";
                else if (direction == "L")
                    direction = "left";
                else if (direction == "R")
                    direction = "right";
                break;
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

        else if (direction == "L")
        {

            foreach (GameObject o1 in R[y].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, 90));
            animation = 3;

        }
        else if (direction == "R")
        {

            foreach (GameObject o1 in R[y].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, -90));
            animation = 4;

        }
        else if (direction == "north")
        {

            foreach (GameObject o1 in C[z].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, -90));
            animation = 5;

        }
        else if (direction == "south")
        {

            foreach (GameObject o1 in C[z].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, -90));
            animation = 6;

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

        changedQuads = new List<GameObject>();
        enemyList = new List<GameObject>();
        enemyList.Add(GameObject.Find("enemy"));
        gameFinished = false;



    }

    // Update is called once per frame
    void Update () {
        //if (animation == 1 && cubeHolder.transform.rotation)
        //{
        //    cubeHolder.transform.Rotate(new Vector3(0, 90*Time.deltaTime, 0));
        //}
       // cubeHolder.transform.Rotate(new Vector3(10,0,0));
        if(enemyList.Contains(null) && !gameFinished)
        {
            Instantiate(WinCanvas);
            gameFinished = true;
        }
		
	}


    IEnumerator rotator()
    {
       
        for (int i = 0; i < 18; i++) // will run the loop 45 times
        {
            if (animation == 1)
            {
                cubeHolder.transform.Rotate(new Vector3(0, 5, 0));
            }
            if (animation == 2)
            {
                cubeHolder.transform.Rotate(new Vector3(0, -5, 0));
            }
            if (animation == 3)
            {
                cubeHolder.transform.Rotate(new Vector3(0, 0, 5));
            }
            if (animation == 4)
            {
                cubeHolder.transform.Rotate(new Vector3(0, 0, -5));
            }
            if (animation == 5)
            {
                cubeHolder.transform.Rotate(new Vector3(5, 0, 0));
            }
            if (animation == 6)
            {
                cubeHolder.transform.Rotate(new Vector3(-5, 0, 0));
            }

            yield return new WaitForSeconds(0.05f); // whatever time you want between loop iterations in seconds put in brackets so 1.0 would be on for 1 second then turn off 0.1 would be a tenth of a second
        }
        cubeHolder.transform.DetachChildren();
        yield break; // will stop the co-routine after all 45 iterations
    }

    public IEnumerator MoveObject(GameObject obj, Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        //obj.transform.position = target;
    }
}
