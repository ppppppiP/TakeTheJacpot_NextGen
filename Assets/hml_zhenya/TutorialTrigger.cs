using DG.Tweening;
using UnityEngine;

public class TutorialTrigger: MonoBehaviour
{
    [SerializeField] GameObject Tutor;
    [SerializeField] Ease ease;
    Tween tween;

    private void OnTriggerEnter(Collider other)
    {
        Tutor.SetActive(true);
        Tutor.transform.localScale = Vector3.zero;
        tween = Tutor.transform.DOScale(Vector3.one, 0.5f)
                               .SetEase(ease)
                               .OnComplete(() => gameObject.SetActive(false));
    }
}