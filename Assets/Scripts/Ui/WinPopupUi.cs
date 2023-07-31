using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ui
{
    [RequireComponent(typeof(Canvas))]
    public class WinPopupUi : MonoBehaviour
    {
        [SerializeField] private List<WinStarUi> stars;
        [SerializeField] private float delay = 0.3f;
        private Canvas canvas;

        private void Awake()
        {
            canvas = GetComponent<Canvas>();
            
            foreach (var winStarUi in stars)
            {
                winStarUi.Hide();
            }

            canvas.enabled = false;
        }

        public void Show(int starsCount)
        {
            StartCoroutine(DelayedShow(starsCount));
        }

        private IEnumerator DelayedShow(int starsCount)
        {
            yield return new WaitForSeconds(delay);
            canvas.enabled = true;
            yield return ShowStars(starsCount);
        }

        private IEnumerator ShowStars(int count)
        {
            foreach (var winStarUi in stars.Take(count))
            {
                yield return winStarUi.Show();
            }
        }
    }
}