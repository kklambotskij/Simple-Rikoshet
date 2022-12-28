using UnityEngine;

public class ControlledByPlayer : MovementBehaviour
{
    [SerializeField] Gunner gunner;
    private void Update()
    {
        direction = transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed;
        rotation.y = Input.GetAxisRaw("Horizontal") * rotateSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gunner.Shoot();
        }
    }
}
