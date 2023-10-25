using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pass_collector : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] Text text;
    private void OnTriggerEnter(Collider other)
    { if (other.TryGetComponent(out PlayerController pla))
        {
            PlayerController.Pass.pass += 1;
            text.text = PlayerController.Pass.pass.ToString();
            gameObject.SetActive(false);
        }
    }
}
