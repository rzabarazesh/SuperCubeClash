using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightController : MonoBehaviour {

    public Material material;
    public Renderer rend;
    public Shader shader1;
    public Shader shader2;

    private bool selected = false;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.material = material;
        var shader1 = new Shader();
        var shader2 = new Shader();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        // Change materials
        /* if(materials.Length == 0)
         {
             return;
         }

         if (Input.GetMouseButtonDown(0))
         {
             if (selected)
             {
                 rend.sharedMaterial = materials[1];
                 selected = false;
             }

             else
             {
                 rend.sharedMaterials = materials;
                 selected = true;
             }

         }*/

        //Change shader



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

    }
}
