using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject targetPosition;
    private Vector3 targetedPosition;
    public Vector3 cameraOffset;
    public float smoothTime;
    private Vector3 velocity;

    void Start()
    {

    }


    void Update()
    {
        targetedPosition = targetPosition.transform.position + cameraOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
    }
}