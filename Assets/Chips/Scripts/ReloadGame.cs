using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    // Start is called before the first frame update
   public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
<<<<<<< HEAD

=======
        
>>>>>>> 3f4f68198b2179b3bdc9c921f5e08e43056d9965
    }
}
