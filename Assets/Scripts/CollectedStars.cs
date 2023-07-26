using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectedStars : MonoBehaviour
{
    [Header("Dependencies")] [SerializeField]
    private List<Star> stars;

    [Header("Debug")] [SerializeField] private int count;

    public int Count => count;

    private void Awake()
    {
        stars = GetComponentsInChildren<Star>().ToList();
        foreach (var star in stars)
        {
            void Increment()
            {
                count++;
                star.onCollected.RemoveListener(Increment);
            }

            star.onCollected.AddListener(Increment);
        }
    }
}