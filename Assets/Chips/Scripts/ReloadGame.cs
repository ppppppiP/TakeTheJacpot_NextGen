using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    // Start is called before the first frame update
   public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
