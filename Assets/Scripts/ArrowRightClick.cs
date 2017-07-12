using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowRightClick : MonoBehaviour, IPointerClickHandler
{

    private GameManager gm;
    public void OnPointerClick(PointerEventData eventData)
    {
        gm.rotateBlocks("right");
    }

    // Use this for initialization
    void Start()
    {

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

}
