using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{



    //float minimumDistance = 0.1f;
    
    [SerializeField] private float rotationSpeed = 5f;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - mainCamera.transform.position.z));

        Vector3 lookDirection = mousePosition - transform.position;
        lookDirection.y = 0f;

        if (lookDirection.magnitude > 0.01f )
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

