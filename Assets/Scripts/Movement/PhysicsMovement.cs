using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsMovement : MonoBehaviour
{
    [SerializeField]
    MovementBehaviour movementBehaviour;

    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (movementBehaviour != null)
        {
            _rigidBody.MovePosition(_rigidBody.position + movementBehaviour.GetDirection() * Time.fixedDeltaTime);
            _rigidBody.MoveRotation(_rigidBody.rotation * Quaternion.Euler(movementBehaviour.GetRotation() * Time.fixedDeltaTime));
        }
    }
}
