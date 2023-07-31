using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallRestores : MonoBehaviour
{
    [SerializeField] private Transform restorePoint;
    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (restorePoint is null)
        {
            throw new NullReferenceException("Restore point is not specified");
        }
        Debug.Log($"Restore point at {restorePoint.position}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FallZone"))
        {
            rigidbody.velocity = Vector3.zero;
            transform.position = restorePoint.position;
        }
    }
}