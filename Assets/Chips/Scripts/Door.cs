using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Door_opener : MonoBehaviour
{
    public float rotationAngle = 90f; // ”гол поворота двери
    private bool isOpen = false;
    [SerializeField] GameObject game;
  
    
    [SerializeField] int MaxPass;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip clip;
    private void Update()
    {
       
    }
   
    private void OnTriggerStay(Collider other)
    {
        
        if (!isOpen && other.TryGetComponent(out PlayerController pla)&&PlayerController.Pass.pass>=MaxPass && Input.GetKeyDown(KeyCode.E)) 
        {
            anim.CrossFade("Inter", 0.1f);
            RotateDoor();
            audio.clip = clip;
            audio.Play();
        }
    }

    private void RotateDoor()
    {
        game.transform.Rotate(Vector3.up, rotationAngle);
        isOpen = true;
    }
}
