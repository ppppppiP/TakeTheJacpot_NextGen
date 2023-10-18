using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detect : MonoBehaviour
{
    [SerializeField] float Timer;
    [SerializeField] Collider col;
    bool detected;
    bool detected1;
    private void Update()
    {
        if (detected)
        {
            StartCoroutine(Detect_Player());
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Detect_Player());
        if(other.TryGetComponent<PlayerController>(out PlayerController pla))
        {
           detected = true;
            
        }
    }
    IEnumerator Detect_Player()
    {
        yield return new WaitForSeconds(Timer);
       
    }
}
