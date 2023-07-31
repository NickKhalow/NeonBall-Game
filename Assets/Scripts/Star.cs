using System;
using System.Linq;
using Extensions;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Star : MonoBehaviour
{
    public UnityEvent onCollected = new();
    [SerializeField] private new ParticleSystem particleSystem;

    private void Awake()
    {
        if (GetComponents<Collider>().Any(c => c.isTrigger == false))
        {
            throw new Exception("Collider must to be trigger");
        }

        particleSystem.EnsureNotNull("Particle system not specified");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball _))
        {
            onCollected.Invoke();
            PlayEffect();
            Destroy(gameObject);
        }
    }

    private void PlayEffect()
    {
        particleSystem.transform.SetParent(null);
        particleSystem.Play();
        Destroy(particleSystem.gameObject, particleSystem.main.duration);
    }
}