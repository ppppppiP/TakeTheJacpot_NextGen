using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
{
    [SerializeField] GameObject Tutor;
    [SerializeField] Ease ease;
    Tween tween;
    void Start()
    {
        
    }

    public void OnButtonClick()
    {
        tween = Tutor.transform.DOScale(Vector3.zero, 0.5f)
                               .SetEase(ease)
                               .OnComplete(()=>Tutor.SetActive(false));
    }
}
