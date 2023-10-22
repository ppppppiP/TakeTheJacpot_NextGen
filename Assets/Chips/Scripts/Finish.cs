using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject finish;
    
    private void OnTriggerEnter(Collider other)
    {
    
        if (other.TryGetComponent<PlayerController>(out PlayerController pla)&&pla.finish == true)
        {
            finish.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
