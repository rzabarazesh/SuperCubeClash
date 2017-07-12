using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject movesUIText;
    private GameObject cubeHolder;
    private GameObject[] L, R, C;
    private GameObject player;
    private GameObject clickedObject;
    private GameObject selectedPiece;
    private List<GameObject> enemyList;
    private int animation;
    private int animateFrames;
    public List<GameObject> changedQuads;
    public GameObject WinCanvas;
    private int face;
    private bool gameFinished;
    private bool gateOpened;
    public GameObject Gate;
    public GameObject ArrowUP;
    public GameObject ArrowDOWN;
    public GameObject ArrowLEFT;
    public GameObject ArrowRIGHT;
    private int moves;
    private int powerMoves;
    public GameObject A_Up;
    public GameObject A_Down;
    public GameObject A_Left;
    public GameObject A_Right;
    public int moveL;
   // public GameObject winPanel;
    public GameObject losePanel;
    
    public int getMoves()
    {
        return moves;
    }
    public void setMoves(int m)
    {
        moves = m; return;
    }
    public void decMoves()
    {
        if (isPowerUp())
        {
            powerMoves--;
        }
        moves--;return;
    }
    public void powerUp()
    {
        powerMoves = 5;
    }
    public bool isPowerUp()
    {
        return (powerMoves > 0);
    }
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
        moves--;
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
                    direction = "L";
                else if (direction == "south")
                    direction = "R";
                else if (direction == "left")
                    direction = "right";
                else if (direction == "right")
                    direction = "left";
                break;
            case 4:
                if (direction == "left")
                    direction = "right";
                else if (direction == "right")
                    direction = "left";

                break;
            case 5:
                if (direction == "north")
                    direction = "R";
                else if (direction == "south")
                    direction = "L";
                else if (direction == "left")
                    direction = "right";
                else if (direction == "right")
                    direction = "left";
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
                if (o1.CompareTag("staticBlock"))
                {
                    cubeHolder.transform.DetachChildren();
                    goto FailToRotate;

                }
            }
            //cubeHolder.transform.Rotate(new Vector3(0, 90, 0));
            animation = 1;


        }

        else if (direction == "right")
        {
            foreach (GameObject o1 in L[x].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);
                if (o1.CompareTag("staticBlock"))
                {
                    cubeHolder.transform.DetachChildren();
                    goto FailToRotate;

                }

            }
            //cubeHolder.transform.Rotate(new Vector3(0, -90, 0));
            animation = 2;

        }

        else if (direction == "L")
        {

            foreach (GameObject o1 in R[y].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);
                if (o1.CompareTag("staticBlock"))
                {
                    cubeHolder.transform.DetachChildren();
                    goto FailToRotate;

                }

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, 90));
            animation = 3;

        }
        else if (direction == "R")
        {

            foreach (GameObject o1 in R[y].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);
                if (o1.CompareTag("staticBlock"))
                {
                    cubeHolder.transform.DetachChildren();
                    goto FailToRotate;

                }

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, -90));
            animation = 4;

        }
        else if (direction == "north")
        {

            foreach (GameObject o1 in C[z].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);
                if (o1.CompareTag("staticBlock"))
                {
                    cubeHolder.transform.DetachChildren();
                    goto FailToRotate;

                }

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, -90));
            animation = 5;

        }
        else if (direction == "south")
        {

            foreach (GameObject o1 in C[z].GetComponent<collidorScript>().getinside())
            {
                o1.transform.SetParent(cubeHolder.transform);
                if (o1.CompareTag("staticBlock"))
                {
                    cubeHolder.transform.DetachChildren();
                    goto FailToRotate;

                }

            }

            //cubeHolder.transform.Rotate(new Vector3(0, 0, -90));
            animation = 6;

        }
        StartCoroutine(rotator());

        FailToRotate:
        return;


        //cubeHolder.transform.DetachChildren();


    }
    // Use this for initialization


    void Start () {
        animateFrames = 10;
        L = new GameObject[4];
        R = new GameObject[4];
        C = new GameObject[4];
        powerMoves = 0;
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
        
        player = GameObject.Find("Player");

        cubeHolder = GameObject.Find("CubeHolder");
        animation = 0;

        moves = moveL;

        changedQuads = new List<GameObject>();
        enemyList = new List<GameObject>();
        enemyList.Add(GameObject.Find("enemy1"));
        enemyList.Add(GameObject.Find("enemy2"));
        enemyList.Add(GameObject.Find("enemy3"));
        enemyList.Add(GameObject.Find("enemy4"));
        gameFinished = false;
        gateOpened = false;


    }
    private string checkstate()
    {
        int aliveEnemies = 0;
        
        if ( moves <= 0 || player == null)
        {
            return "lose";
        }
        foreach (GameObject enemy in enemyList)
        {
            if (enemy!= null)
            {
                aliveEnemies++;
            }
        }

        if (aliveEnemies == 0)
        {
            return "openGate";
        }
        return "inprogress";
    }

    // Update is called once per frame
    void Update () {
        //if (animation == 1 && cubeHolder.transform.rotation)
        //{
        //    cubeHolder.transform.Rotate(new Vector3(0, 90*Time.deltaTime, 0));
        //}
       // cubeHolder.transform.Rotate(new Vector3(10,0,0));
        if(checkstate()== "openGate" && !gateOpened)
        {
            //Instantiate(WinCanvas);
            //winPanel.SetActive(true);
            Gate.GetComponent<GateController>().open();
            gateOpened = true;
        }
        if (checkstate() == "lose" && !gameFinished)
        {
            //Instantiate(WinCanvas);
            losePanel.SetActive(true);
            gameFinished = true;
        }

        movesUIText.GetComponent<UnityEngine.UI.Text>().text = ""+(getMoves());
        if (isPowerUp())
        {
            movesUIText.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        }
        else
        {
            movesUIText.GetComponent<UnityEngine.UI.Text>().color = Color.black;
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
            if(obj!=null)
                obj.transform.position = Vector3.Lerp(obj.transform.position, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        //obj.transform.position = target;
    }

    public void showArrows(int face)
    {
        if (face == 1)
        {
            A_Down = Instantiate(ArrowDOWN, new Vector3(0, -2.5f, -2), Quaternion.Euler(0, 0, 0));
            A_Up = Instantiate(ArrowUP, new Vector3(0, 2.5f, -2), Quaternion.Euler(0, 0, 0));
            A_Left = Instantiate(ArrowLEFT, new Vector3(-2.5f, 0, -2), Quaternion.Euler(0, 0, 0));
            A_Right = Instantiate(ArrowRIGHT, new Vector3(2.5f, 0, -2), Quaternion.Euler(0, 0, 0));
        }
        if (face == 4)
        {
            A_Down = Instantiate(ArrowDOWN, new Vector3(0, 2.5f, 2), Quaternion.Euler(180, 0, 0));
            A_Up = Instantiate(ArrowUP, new Vector3(0, -2.5f, 2), Quaternion.Euler(180, 0, 0)); 
            A_Left = Instantiate(ArrowLEFT, new Vector3(-2.5f, 0, 2), Quaternion.Euler(180, 0, 0));
            A_Right = Instantiate(ArrowRIGHT, new Vector3(2.5f, 0, 2), Quaternion.Euler(180, 0, 0));
        }

        if (face == 2)
        {

            A_Down = Instantiate(ArrowDOWN, new Vector3(0, 2, -2.5f), Quaternion.Euler(90, 0, 0));
            A_Up = Instantiate(ArrowUP, new Vector3(0, 2, 2.5f), Quaternion.Euler(90, 0, 0));
            A_Left = Instantiate(ArrowLEFT, new Vector3(-2.5f, 2, 0), Quaternion.Euler(90, 0, 0));
            A_Right = Instantiate(ArrowRIGHT, new Vector3(2.5f, 2, 0), Quaternion.Euler(90, 0, 0));
        }

        if (face == 6)
        {
            A_Down = Instantiate(ArrowDOWN, new Vector3(0, -2, 2.5f), Quaternion.Euler(-90, 0, 0));
            A_Up = Instantiate(ArrowUP, new Vector3(0, -2, -2.5f), Quaternion.Euler(-90, 0, 0));
            A_Left = Instantiate(ArrowLEFT, new Vector3(-2.5f, -2, 0), Quaternion.Euler(-90, 0, 0));
            A_Right = Instantiate(ArrowRIGHT, new Vector3(2.5f, -2, 0), Quaternion.Euler(-90, 0, 0));
        }

        if (face == 3)
        {
            A_Down = Instantiate(ArrowDOWN, new Vector3(-2, 2.5f, 0), Quaternion.Euler(180, -90, 0));
            A_Up = Instantiate(ArrowUP, new Vector3(-2, -2.5f, 0), Quaternion.Euler(180, -90, 0));
            A_Left = Instantiate(ArrowLEFT, new Vector3(-2f, 0, -2.5f), Quaternion.Euler(180, -90, 0));
            A_Right = Instantiate(ArrowRIGHT, new Vector3(-2f, 0, 2.5f), Quaternion.Euler(180, -90, 0));
        }

        if (face == 5)
        {
            A_Down = Instantiate(ArrowDOWN, new Vector3(2, 2.5f, 0), Quaternion.Euler(180, 90, 0));
            A_Up = Instantiate(ArrowUP, new Vector3(2, -2.5f, 0), Quaternion.Euler(180, 90, 0));
            A_Left = Instantiate(ArrowLEFT, new Vector3(2, 0, 2.5f), Quaternion.Euler(180, 90, 0));
            A_Right = Instantiate(ArrowRIGHT, new Vector3(2, 0, -2.5f), Quaternion.Euler(180, 90, 0));
        }

    }

    public void hideArrows()
    {
        //if(A_Left != null)
        Destroy(A_Left);
        //if (A_Down != null)
        Destroy(A_Down);
        //if (A_Right != null)
        Destroy(A_Right);
        //if (A_Up != null)
        Destroy(A_Up);
    }
}
