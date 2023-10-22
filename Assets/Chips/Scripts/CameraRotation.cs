using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
   [SerializeField]  float rotationSpeed = 30f;
    [SerializeField] float maxRotationAngle = 90f;
    [SerializeField] float pauseDuration = 2f;

    private int rotationDirection = 1;
    private bool isPaused = false;

    void Start()
    {
        StartCoroutine(RotateWithPause());
    }

    IEnumerator RotateWithPause()
    {
        while (true)
        {
            if (!isPaused)
            {
                transform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);

                if (Mathf.Abs(transform.rotation.eulerAngles.y) >= maxRotationAngle)
                {
                    rotationDirection *= -1;
                    isPaused = true;
                    yield return new WaitForSeconds(pauseDuration);
                    isPaused = false;
                }
            }
            yield return null;
        }
    }
}

