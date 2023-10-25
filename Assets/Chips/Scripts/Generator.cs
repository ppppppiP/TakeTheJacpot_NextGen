using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_off : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject image;
    [SerializeField] Animator anim;
    [SerializeField] GameObject Effects;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip Generator;
    [SerializeField] AudioClip EffectsClip;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController pl))
        {
            image.SetActive(true);
        }
        if (other.TryGetComponent<PlayerController>(out PlayerController pla)&&Input.GetKeyDown(KeyCode.E))
        {
            laser.SetActive(false);
            anim.CrossFade("Inter", 0.1f);
            Effects.SetActive(true);
            audio.clip = EffectsClip;
          audio.Play();
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
