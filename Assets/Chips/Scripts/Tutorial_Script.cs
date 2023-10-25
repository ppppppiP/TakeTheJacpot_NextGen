using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutor;
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out PlayerController pla))
        {
            tutor.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController pla))
        {
            tutor.SetActive(false);
        }
    }
}
