using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightController : MonoBehaviour
{


    public Renderer rend;
    public Shader shader1;
    public Shader shader2;

    private bool selected = false;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        shader1 = Shader.Find("Outlined/Silhouetted Diffuse");
        shader2 = Shader.Find("Standard");
    }

    private void OnMouseDown()
    {
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
