using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Detect : MonoBehaviour
{
    [SerializeField] float Timer;
    [SerializeField] float DetectTime;
    [SerializeField] float speed;
    [SerializeField] private Transform position1, position2;
    private bool _switch = false;
    bool detected = false;
    public bool lose = false;
    [SerializeField] Image detect_image;
    [SerializeField] GameObject enemy;
    float percent;
    [SerializeField] float normalSpeed;
    float zeroSpeed = 0;
    float EnemyStayTimer = 0;
    [SerializeField] float EnemyStayTimeMax;

    [SerializeField] Transform camera;
    [SerializeField] Transform image;
    private void Update()
    {
        image.LookAt(camera);


        if (_switch == false)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, position1.position, speed * Time.deltaTime);
            EnemyStay();

        }
        else if (_switch == true)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, position2.position, speed * Time.deltaTime);
            EnemyStay();

        }

        if (enemy.transform.position == position1.position)
        {

            _switch = true;
            EnemyMove();
        }
        else if (enemy.transform.position == position2.position)
        {


            _switch = false;
            EnemyMove();
        }

        ImageFill1();

        if (detected)
        {
            Detected();

            DetectUp();

        }
        else
        {
            DetectDown();

        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<PlayerController>(out PlayerController pla))
        {
            detected = true;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController pla))
        {
            detected = false;

        }

    }
    private void DetectUp()
    {
        DetectTime += 1f * Time.deltaTime;


    }
    private void DetectDown()
    {

        if (DetectTime > 0)
        {
            DetectTime -= 0.1f;
            if (DetectTime <= 0)
            {
                DetectTime = 0;

            }
        }
    }
    private void Detected()
    {
        if (DetectTime >= Timer)
        {

           
            UIAdministrator.Menu.LoseMenu.active = true;
            Time.timeScale = 0;
        }
    }
    void ImageFill1()
    {
        percent = DetectTime / Timer;
        detect_image.fillAmount = percent;
    }
    void EnemyStay()
    {
        EnemyStayTimer += 1f * Time.deltaTime;
        speed = zeroSpeed;
        if (EnemyStayTimer >= EnemyStayTimeMax)
        {
            speed = normalSpeed;
            if (_switch == true)
            { enemy.transform.LookAt(position2); }
            else if (_switch == false)
            { enemy.transform.LookAt(position1); }


        }

    }
    void EnemyMove()
    {
        if (EnemyStayTimer >= 0)
        {

            EnemyStayTimer = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }
}
