using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    [SerializeField] float DetectTime;
    [SerializeField] float Timer;
    bool detected = false;
    [SerializeField] Transform enemy;
    [SerializeField] Transform target;
    [SerializeField] LayerMask layerMask;
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

            Debug.Log("Detected");
            UIAdministrator.Menu.LoseMenu.active = true;
            Time.timeScale = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(enemy.position, target.position);
    }
}
