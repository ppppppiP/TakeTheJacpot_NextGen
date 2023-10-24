
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightEnemy : MonoBehaviour
{
    [SerializeField] float DetectTime;
    [SerializeField] float Timer;
    bool detected = false;
    [SerializeField] Transform enemy;
    [SerializeField] Transform target;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Image image;
    float percent;
   
    private void Update()
    {
       if( Physics.Linecast(enemy.position, target.position, layerMask))
        {
            detected = false;
        }
        if (detected)
        {
            Detected();

            DetectUp();

        }
        else
        {
            DetectDown();

        }
        ImageFill();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<PlayerController>(out PlayerController pla))
        {
            detected = true;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController pla))
        {
            detected = false;

        }

    }
    private void DetectUp()
    {
        DetectTime += 0.1f;


    }
    private void DetectDown()
    {

        if (DetectTime > 0)
        {
            DetectTime -= 0.1f;
            if (DetectTime <= 0)
            {
                DetectTime = 0;

            }
        }
    }
    private void Detected()
    {
        if (DetectTime >= Timer)
        {

          
            UIAdministrator.Menu.LoseMenu.active = true;
            Time.timeScale = 0;
        }
    }
    void ImageFill()
    {
        
        image.fillAmount = DetectTime / Timer;
        
    }
    private void OnDrawGizmos()
    {
        if (target != null && enemy != null )
        {
            Gizmos.DrawLine(enemy.position, target.position);
        }
    }
    
}
