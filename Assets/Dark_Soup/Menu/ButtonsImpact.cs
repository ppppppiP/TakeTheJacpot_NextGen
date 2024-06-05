using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsImpact : MonoBehaviour
{
   public Vector3 upScale = new Vector3(1, 1, 1);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        transform.localScale += upScale;
    }

    private void OnMouseExit()
    {
        transform.localScale -= upScale;
    }
}
