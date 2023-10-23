using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
   [SerializeField]  float rotationSpeed = 30f;
    [SerializeField] float maxRotationAngle = 90f;
    
    [SerializeField] GameObject camera;
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
   
    private bool isPaused = false;
    Transform target;
    [SerializeField] float PauseTime;
     float Timer = 0;
    private void Start()
    {
        target = point1;
    }
    private void Update()
    {
        if (!isPaused)
        {
            camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, Quaternion.LookRotation(target.position-camera.transform.position), rotationSpeed*Time.deltaTime);

           
            if (Quaternion.LookRotation(target.position - camera.transform.position)==camera.transform.rotation)//?
            {    Debug.Log("hjklhjk");
                if (target == point1)
                {
                    target = point2;
                }
                else
                {
                    target = point1;
                }
                
              
                isPaused = true;
                Timer = 0;
            }
            

        }
        else
        {
            Pause_rotation();
            
        }
        
    }


    public void Pause_rotation()
    {
        Timer += 0.1f;
        isPaused = true;
        if (Timer >= PauseTime)
        {
            isPaused = false;
            
        }
    }
    
}

