using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    Transform volocity;
    Vector3 currentPos;

    private void OnEnable()
    {
        if (Pass == null)
        { // Ёкземпл€р менеджера был найден
            Pass = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (Pass == this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }
        Time.timeScale = 1;
       
    }

    private bool isSoundPlaying = false;
    private float soundCooldown = 0.5f; 

    void Update()
    {

        cc.Move(Vector3.down);
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        { Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            anim.SetBool("isWalk", true);
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
        else if (other.TryGetComponent<EnemyAIController>(out EnemyAIController lose1))
        {
            lose = true;
        }
    }

     void Move(Vector2 inputDirection)
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        Vector3 moveDirection = cameraForward * inputDirection.y + cameraRight * inputDirection.x;
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            cc.Move(moveDirection * Speed * Time.deltaTime);

            if (inputDirection != Vector2.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                float rotationSpeed = 5 * Time.deltaTime;

                if (cc.transform.forward != moveDirection)
                {
                    cc.transform.rotation = Quaternion.RotateTowards(cc.transform.rotation, targetRotation, rotationSpeed);
                }
            }
        }

        if (inputDirection != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            float rotationSpeed = 100 * Time.deltaTime;
            cc.transform.rotation = Quaternion.Lerp(cc.transform.rotation, targetRotation, rotationSpeed);
        }
    }




}
