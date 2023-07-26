using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ui
{
    public class WinPopupUi : MonoBehaviour
    {
        [SerializeField] private List<WinStarUi> stars;

        private void Awake()
        {
            foreach (var winStarUi in stars)
            {
                winStarUi.Hide();
            }
            gameObject.SetActive(false);
        }

        public void Show(int starsCount)
        {
            gameObject.SetActive(true);
            StartCoroutine(ShowStars(starsCount));
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