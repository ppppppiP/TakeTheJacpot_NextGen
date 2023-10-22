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
    bool detected=false;
    public  bool lose = false;
    [SerializeField] Image detect_image;
    
    [SerializeField] GameObject enemy;
    
    [SerializeField] Transform camera;
    [SerializeField] Transform image;
    
    float percent;
    [SerializeField]  float normalSpeed;
    float zeroSpeed = 0;
    float EnemyStayTimer = 0;
    [SerializeField] float EnemyStayTimeMax;
<<<<<<< HEAD
    

    private void Update()
    {
     
        image.LookAt(camera);
        //Vector3 direction = position1.position - enemy.transform.position;
        
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //enemy.transform.rotation = rotation;

=======
   
    [SerializeField] Transform camera;
    [SerializeField] Transform image;
    private void Update()
    {
        image.LookAt(camera);


>>>>>>> 3f4f68198b2179b3bdc9c921f5e08e43056d9965
        if (_switch == false )
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, position1.position, speed * Time.deltaTime);
            EnemyStay();
<<<<<<< HEAD
            enemy.transform.LookAt(position1, Vector3.up);
=======
            
>>>>>>> 3f4f68198b2179b3bdc9c921f5e08e43056d9965
        }
        else if (_switch == true )
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, position2.position, speed * Time.deltaTime);
            EnemyStay();
<<<<<<< HEAD
           enemy.transform.LookAt(position2, Vector3.up);
=======
           
>>>>>>> 3f4f68198b2179b3bdc9c921f5e08e43056d9965
        }

        if (enemy.transform.position== position1.position) {
            
            _switch = true;
            EnemyMove();
        }
        else if(enemy.transform.position == position2.position) {

           
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
       
        if(other.TryGetComponent<PlayerController>(out PlayerController pla))
        {
           detected = true;
<<<<<<< HEAD
           
=======
            
>>>>>>> 3f4f68198b2179b3bdc9c921f5e08e43056d9965
            
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
        DetectTime += 0.1f;
       
        
    }
    private void DetectDown()
    {
        
        if (DetectTime > 0)
        {
            DetectTime -= 0.1f;
            if (DetectTime <= 0)
            {
                DetectTime = 0;
<<<<<<< HEAD
              
=======
               
>>>>>>> 3f4f68198b2179b3bdc9c921f5e08e43056d9965
            }
        }
    }
    private void Detected()
    {
        if(DetectTime >= Timer) 
{
          
            Debug.Log("Detected");
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
        EnemyStayTimer += 0.1f;
        speed = zeroSpeed;
        if(EnemyStayTimer >= EnemyStayTimeMax) 
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
        if(EnemyStayTimer >= 0)
        {
            
            EnemyStayTimer = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }
}
