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


	public void On_Click_Orentation(int _sceneNumber)
		{
			SceneManager.LoadScene(_sceneNumber);
			Time.timeScale = 1;
		}

		public void On_Click_menu()
		{
			a.transform.position = new Vector3(-1000, -1000, 0);
			b.transform.position = new Vector3(-1000, -1000, 0);
			c.transform.position = new Vector3(-1000, -1000, 0);
			Time.timeScale = 1;
		}
		public void On_Click_Game()
		{
			a.transform.position = new Vector3(800, 300, 0);
			b.transform.position = new Vector3(800, 500, 0);
			c.transform.position = new Vector3(800, 250, 0);
			Time.timeScale = 0;
		}
}
