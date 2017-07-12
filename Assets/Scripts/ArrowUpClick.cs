using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowUpClick : MonoBehaviour, IPointerClickHandler
{
   
    private GameManager gm;
    public void OnPointerClick(PointerEventData eventData)
    {
        gm.rotateBlocks("north");
    }

    // Use this for initialization
    void Start () {
        
        gm =GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	

    
}
