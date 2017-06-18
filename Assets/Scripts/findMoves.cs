using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findMoves : MonoBehaviour
{

    private GameObject selectedObject;
    private GameObject[] L, R, C;

    // Use this for initialization
    void Start()
    {
        selectedObject = null;
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

    }
    private void OnMouseDown()
    {
        selectedObject = this.transform.gameObject;
        findmoves();
    }
    // Update is called once per frame
    void findmoves()
    {
        RaycastHit target;
        Ray ray_casting = Camera.main.ScreenPointToRay(Input.mousePosition);
        int face = -1;
        foreach (Transform child in selectedObject.transform)
        {
            if (Physics.Raycast(ray_casting, out target))
                if (target.collider.name == child.name)
                {
                    print("Got Side : " + child.name);
                    Debug.Log(child.name[6]);
                    face = child.name[6] - '0';
                    Debug.Log("face: " + face);
                    break;
                }
                else
                    Debug.Log("Touching nothing !");
        }

        int x = 0, y = 0, z = 0;

        for (int i = 0; i < 4; i++)
            foreach (GameObject o1 in L[i].GetComponent<collidorScript>().getinside())
                if (o1 == selectedObject)
                {
                    z = i;
                    break;
                }
        for (int i = 0; i < 4; i++)
            foreach (GameObject o1 in C[i].GetComponent<collidorScript>().getinside())
                if (o1 == selectedObject)
                {
                    x = i;
                    break;
                }
        for (int i = 0; i < 4; i++)
            foreach (GameObject o1 in R[i].GetComponent<collidorScript>().getinside())
                if (o1 == selectedObject)
                {
                    y = i;
                    break;
                }
        Debug.Log("x: " + x + " y: " + y + " z: " + z);





        GameObject cube_adjecent = find_cube(z, x, y, face); //retrieve cube by ( x, y ,z )
        if (cube_adjecent == null)
            Debug.Log("error! not found cube");
        //test_cube_retrieve(selectedObject, cube_adjecent);


    }

    /*
     * x, y , z : the location of cube we want to find ( 0~ 3 )
     * face the number of quad that user touch on  (1 ~ 6)
     * return : cube object
     */
    GameObject find_cube(int z, int x, int y, int face)
    {

        GameObject cube = new GameObject();

        int i = 0;
        int m = -1;

        int[] R1_match = { 2, 4, 10, 15, 0, 6, 9, 12, 3, 5, 8, 14, 1, 7, 11, 13 };
        int[] R4_match = { 15, 11, 4, 1, 13, 8, 5, 0, 12, 9, 7, 2, 14, 10, 6, 3 };
        int[] L2_match = { 2, 6, 9, 13, 1, 5, 11, 12, 0, 7, 8, 14, 3, 4, 10, 15 };
        int[] L6_match = { 0, 5, 10, 14, 3, 6, 8, 15, 1, 4, 11, 12, 2, 7, 9, 13 };
        int[] C3_match = { 4, 2, 0, 7, 3, 13, 8, 1, 11, 9, 5, 14, 12, 10, 15, 6 };
        int[] C5_match = { 14, 11, 1, 10, 7, 15, 0, 5, 12, 2, 6, 3, 9, 13, 4, 8 };

        if (face == 1 || face == 4)
        {
            if (face == 1)
                m = R1_match[z * 4 + (3 - x)];
            else
                m = R4_match[z * 4 + x];
            //Debug.Log("m: " + m);
            foreach (GameObject o in R[y].GetComponent<collidorScript>().getinside())
            {
                if (i == m)
                {
                    //Debug.Log("i: " + i);
                    cube = o;
                    break;
                }
                i++;
            }
        }
        else if (face == 2 || face == 6)
        {
            if (face == 2)
                m = L2_match[(3 - y) * 4 + (3 - x)];
            else
                m = L6_match[y * 4 + (3 - x)];
            //Debug.Log("m: " + m);
            foreach (GameObject o in L[z].GetComponent<collidorScript>().getinside())
            {
                if (i == m)
                {
                    //Debug.Log("i: " + i);
                    cube = o;
                    break;
                }
                i++;
            }
        }
        else if (face == 3 || face == 5)
        {
            if (face == 3)
                m = C3_match[z * 4 + (3 - y)];
            else
                m = C5_match[z * 4 + y];
            //Debug.Log("m: " + m);
            foreach (GameObject o in C[x].GetComponent<collidorScript>().getinside())
            {
                if (i == m)
                {
                    //Debug.Log("i: " + i);
                    cube = o;
                    break;
                }
                i++;
            }
        }



        return cube;
    }

    void find()
    {

    }

}

