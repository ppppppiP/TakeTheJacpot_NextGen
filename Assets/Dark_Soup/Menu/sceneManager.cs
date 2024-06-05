using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;

public class sceneManager : MonoBehaviour

{
	public GameObject a;
	public GameObject b;
	public GameObject c;
   
    public GameObject f;


    public void On_Click_Orentation(int _sceneNumber)
		{
			SceneManager.LoadScene(_sceneNumber);
			Time.timeScale = 1;
		}

		public void On_Click_menu()
		{
			c.transform.position = new Vector3(213, 0, -47);
			a.transform.position = new Vector3(-1000, -1000, -1000);
		
			b.transform.position = new Vector3(-1000, -1000, -1000);
			
			Time.timeScale = 1;
		}
		public void On_Click_Game()
		{
			a.transform.position = new Vector3(213, 0, -47);
			
			b.transform.position = new Vector3(-1000, -1000, -1000);
			c.transform.position = new Vector3(-1000, -1000, -1000);
			Time.timeScale = 0;
		}
    public void On_Click_1()
    {
     
        a.transform.position = new Vector3(-1000, -1000, -1000);
      
        b.transform.position = new Vector3(213, 0, -47);
        c.transform.position = new Vector3(-1000, -1000, -1000);
        Time.timeScale = 1;
    }
}
