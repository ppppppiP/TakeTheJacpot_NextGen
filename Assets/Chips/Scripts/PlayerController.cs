using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] public float Speed = 10f;
    [SerializeField] GameObject menu;
    public bool finish = false;
    public bool lose = false;
    private void Start()
    {

        Time.timeScale = 1;
    }
    void Update()
    {
      

        float vertical = Input.GetAxisRaw("Vertical");
        

        float horisontal = Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = (vertical * transform.forward + horisontal * transform.right).normalized;
        cc.Move(moveDirection * Speed * Time.deltaTime);


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
    


}
