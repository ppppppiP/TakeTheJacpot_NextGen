using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Taker : MonoBehaviour
{
    // Start is called before the first frame update
   public  bool finish = false;
    [SerializeField]GameObject gold;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if( other.TryGetComponent<PlayerController>(out PlayerController pla))
            {
            gold.active = false;
                finish = true;
            //gold.active = false;
            }
    }
    //public bool isTrue(bool fin)
    //{
    //    if(finish)
    //    {
    //        return fin = true;
    //    }
    //    else
    //    {
    //        return fin = false;
    //    }
    //}
}
