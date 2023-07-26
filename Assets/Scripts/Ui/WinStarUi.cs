using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Ui
{
    public class WinStarUi : MonoBehaviour
    {
        [SerializeField] private float showDuration = 0.3f;
        [SerializeField] private Ease ease = Ease.Linear;

        [ContextMenu(nameof(Show))]
        public void ShowNoWait()
        {
            StartCoroutine(Show());
        }

        public IEnumerator Show()
        {
            transform.DOScale(1, showDuration).SetEase(ease);
            yield return new WaitForSeconds(showDuration);
        }

        [ContextMenu(nameof(Hide))]
        public void Hide()
        {
            transform.localScale = Vector3.zero;
        }
    }
}