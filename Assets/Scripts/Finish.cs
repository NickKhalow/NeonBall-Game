using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Extensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Finish : MonoBehaviour
{
    public UnityEvent onPlayerEnter = new();
    [SerializeField] private Transform finishPosition;
    [SerializeField] private float catchDuration = 2;
    [Header("Debug")] [SerializeField] private bool finished = false;

    private void Awake()
    {
        if (finished)
        {
            Debug.LogWarning("Should not be finished at start");
        }

        finishPosition.EnsureNotNull("Not found finish position");
        if (GetComponents<Collider>().Any(c => c.isTrigger == false))
        {
            throw new Exception("Collider must to be trigger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (finished == false && other.TryGetComponent<Ball>(out var ball))
        {
            onPlayerEnter.Invoke();
            ball.Freeze();
            ball.transform.DOMove(finishPosition.position, catchDuration);
            finished = true;
        }
    }
}