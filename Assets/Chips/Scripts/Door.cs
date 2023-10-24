using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Door_opener : MonoBehaviour
{
    public float rotationAngle = 90f; // ”гол поворота двери
    private bool isOpen = false;
    [SerializeField] GameObject game;
    public int pass;
    public static Door_opener Pass;
    [SerializeField] int MaxPass;
    [SerializeField] Animator anim;
    private void Update()
    {
         Pass = this;
    }
   
    private void OnTriggerStay(Collider other)
    {
        
        if (!isOpen && other.TryGetComponent(out PlayerController pla)&&pass>=MaxPass && Input.GetKeyDown(KeyCode.E)) 
        {
            anim.CrossFade("Inter", 0.1f);
            RotateDoor();
        }
    }

    private void RotateDoor()
    {
        game.transform.Rotate(Vector3.up, rotationAngle);
        isOpen = true;
    }
}
