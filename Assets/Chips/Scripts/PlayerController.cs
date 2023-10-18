using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] public float Speed = 10f;
    [SerializeField] GameObject menu;
    public bool finish = false;

    private void Start()
    {

        Time.timeScale = 1;
    }
    void Update()
    {
      

        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move_vert = transform.forward;
        cc.Move(vertical * move_vert * Speed * Time.deltaTime);

        float horisontal = Input.GetAxisRaw("Horizontal");
        Vector3 move_horizon = transform.right;
        cc.Move(horisontal * move_horizon * Speed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Finish_Taker>(out Finish_Taker fin))
        {
            finish = true;
        }
        else if (other.TryGetComponent<Enemy_Detect>(out Enemy_Detect lose))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    


}
