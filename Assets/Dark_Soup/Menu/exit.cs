using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
	public void On_Click_button()
	{
		Debug.Log("Работает");
		Application.Quit();
	}
}
