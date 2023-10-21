using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
   [SerializeField] float rotationSpeed = 20.0f; 
   [SerializeField] float maxRotationAngle = 90.0f;

    private int rotationDirection = 1; 

    void Update()
    {
        
        transform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);

        if (Mathf.Abs(transform.rotation.eulerAngles.y) >= maxRotationAngle)
        {
            rotationDirection *= -1;
        }
    }
}
