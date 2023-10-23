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
            Door_opener.Pass.pass += 1;
            text.text = Door_opener.Pass.pass.ToString();
            gameObject.SetActive(false);
        }
    }
}
