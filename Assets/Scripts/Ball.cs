using Extensions;
using Inputs;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Ball : MonoBehaviour
{
    [Header("Dependencies")] [SerializeField]
    private AbstractInput input;

    [Header("Config")] [SerializeField] private float speed = 20;
    private new Rigidbody rigidbody;

    private void Start()
    {
        input.EnsureNotNull("Input is not provided");
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidbody.AddForce(Direction() * (speed * Time.deltaTime));
    }

    private Vector3 Direction()
    {
        var flat = input.Direction();
        return new Vector3(flat.x, 0, flat.y);
    }

    [ContextMenu(nameof(Freeze))]
    public void Freeze()
    {
        rigidbody.isKinematic = true;
    }
}