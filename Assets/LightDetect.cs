using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetect : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<CharacterController>(out CharacterController pla))
        {
            UIAdministrator.Menu.LoseMenu.active = true;
            Time.timeScale = 0;
        }
    }
}
