using UnityEngine;

public abstract class MovementBehaviour : MonoBehaviour
{
    [SerializeField] 
    protected float moveSpeed = 5;

    [SerializeField]
    protected float rotateSpeed = 100;

    protected Vector3 direction = new Vector3();
    protected Vector3 rotation = new Vector3();

    public Vector3 GetDirection()
    {
        return direction;
    }
    public Vector3 GetRotation()
    {
        return rotation;
    }
}
