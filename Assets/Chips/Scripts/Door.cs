using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Door_opener : MonoBehaviour
{
    public float rotationAngle = 90f; // ”гол поворота двери
    private bool isOpen = false;
    [SerializeField] GameObject game;
    bool enter = false;
    
    [SerializeField] int MaxPass;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip clip;
    private void Update()
    {
        if (enter)
        {
            if (!isOpen && PlayerController.Pass.pass >= MaxPass && Input.GetKeyDown(KeyCode.E))
            {
                anim.CrossFade("Inter", 0.1f);
                RotateDoor();
                audio.clip = clip;
                audio.Play();
            }
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            enter = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            enter = false;
        }

    }


    private void RotateDoor()
    {
        game.transform.Rotate(Vector3.up, rotationAngle);
        isOpen = true;
    }
}
