using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 direction;
    private float speed = 5;
    private Rigidbody _rigidbody;
    private Gunner gunner;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + direction * speed * Time.fixedDeltaTime) ;
    }

    public void SetDirection(Vector3 vec3)
    {
        direction = vec3;
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
}
