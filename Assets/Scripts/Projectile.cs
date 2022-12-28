using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionMask;

    private float speed = 5;
    private Rigidbody _rigidbody;
    private Gunner gunner;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, transform.localScale.x + 0.1f, collisionMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }

        _rigidbody.MovePosition(_rigidbody.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    public void SetGunner(Gunner gun)
    {
        gunner = gun;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Gunner enemy = collision.collider.GetComponent<Gunner>();
        if (enemy != null)
        {
            gunner.ScoreUp();
            gunner.Restart();
            enemy.Restart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Field field = other.GetComponent<Field>();
        if (field != null)
        {
            Destroy(gameObject);
        }
    }
}
