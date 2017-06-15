using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZoom : MonoBehaviour {

    float previousDistance;
    float zoomSpeed = 1.0f;
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.touchCount == 2 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began))
        {
            previousDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
        }

        else if (Input.touchCount == 2 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
        {
            float distance;
            Vector2 touch1 = Input.GetTouch(0).position;
            Vector2 touch2 = Input.GetTouch(1).position;

            distance = Vector2.Distance(touch1, touch2);

            float pinchAmount = (previousDistance - distance) * zoomSpeed * Time.deltaTime;
            Camera.main.transform.Translate(0,0,-pinchAmount);

            previousDistance = distance;
        }
	}
}
