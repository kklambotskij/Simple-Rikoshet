using System.Collections;
using UnityEngine;

public class AIControlled : MovementBehaviour
{
    [SerializeField]
    private LayerMask gunnerMask;

    [SerializeField] Gunner gunner;

    private float timer = 0;
    private float cooldown = 0.1f;

    private void Update()
    {
        timer += Time.deltaTime;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10, gunnerMask))
        {
            if (timer >= cooldown)
            {
                gunner.Shoot();
                timer = 0;
            }
        }
        rotation.y = Random.Range(-1, 1) * rotateSpeed;
    }
}
