using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] public float Speed = 10f;
    [SerializeField] GameObject menu;
    public bool finish = false;
    public bool lose = false;

    [SerializeField] Animator anim;
    private Vector3 moveDirection;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Controller();
            
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        
        RotateTowardsMovement();
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
            if (vertical != -1)
            {
                anim.SetBool("isWalk", true);
                moveDirection = (vertical * transform.forward + horisontal * transform.right).normalized;
                cc.Move(moveDirection * Speed * Time.deltaTime);
            }
            

        }

        private void RotateTowardsMovement()
       {
        
      
            
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Speed);
      
    }
}
