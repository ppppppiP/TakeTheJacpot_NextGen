using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;

public class sceneManagew : MonoBehaviour

{
    public void On_Click_Oren(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
        Time.timeScale = 1;
    }
    public void On_Click_Orentatio(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
        Time.timeScale = 1;
    }

}

