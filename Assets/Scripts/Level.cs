using Extensions;
using Ui;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Finish finish;
    [SerializeField] private WinPopupUi winPopupUi;
    [SerializeField] private CollectedStars collectedStars;

    private void Awake()
    {
        finish.EnsureNotNull("Finish is not provided");
        winPopupUi.EnsureNotNull("Win popup is not provided");
        collectedStars.EnsureNotNull("Stars is not provided");
    }

    private void Start()
    {
        finish.onPlayerEnter.AddListener(() =>
            {
                Debug.Log("Show win popup!");
                winPopupUi.Show(collectedStars.Count);
            }
        );
    }
}