using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private const float MIN_DIST = 20.0f;
    private const float MAX_DIST = 120.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Start()
    {
        
        cam = Camera.main;
    }

    private void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");
            distance += Input.GetAxis("Mouse ScrollWheel");
            distance = Mathf.Clamp(distance, MIN_DIST, MAX_DIST);
        //}


    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}


