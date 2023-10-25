using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEditor.ShaderData;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] public float Speed = 10f;
    [SerializeField] GameObject menu;
    public bool finish = false;
    public bool lose = false;
    bool isStep;
    [SerializeField] Animator anim;
    private Vector3 moveDirection;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip steps;
    public int pass;
    public static PlayerController Pass;
    private void Start()
    {
        Time.timeScale = 1;
    }

    private bool isSoundPlaying = false;
    private float soundCooldown = 0.5f; 

    void Update()
    {
        Pass = this;
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {Controller();
            if (!isSoundPlaying) 
            {
                
                audio.clip = steps;
                audio.Play();
                isSoundPlaying = true;
                StartCoroutine(SoundCooldown());
            }
        }
        else
        {
            audio.Pause();
            anim.SetBool("isWalk", false);
        }
    }

    IEnumerator SoundCooldown()
    {
        yield return new WaitForSeconds(soundCooldown);
        isSoundPlaying = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Finish_Taker>(out Finish_Taker fin))
        {
            finish = true;
        }
        else if (other.TryGetComponent<Enemy_Detect>(out Enemy_Detect lose1))
        {
            lose = true;
        }
    }

   
        private void Controller()
        {
            float vertical = Input.GetAxisRaw("Vertical");
            float horisontal = Input.GetAxisRaw("Horizontal");
          anim.SetBool("isWalk", true);
                moveDirection = (vertical * transform.forward + horisontal * transform.right).normalized;
                cc.Move(moveDirection * Speed * Time.deltaTime);
        
        
          
      
             if (vertical != -1)
    {
        Quaternion rotation = Quaternion.LookRotation(moveDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Speed);
    }

        }

       


   
    
}
