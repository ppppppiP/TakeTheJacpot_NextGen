using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_off : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject image;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController pl))
        {
            image.SetActive(true);
        }
        if (other.TryGetComponent<PlayerController>(out PlayerController pla)&&Input.GetKeyDown(KeyCode.E))
        {
            laser.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController pl))
        {
            image.SetActive(false);
        }

    }

}
