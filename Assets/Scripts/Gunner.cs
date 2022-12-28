using TMPro;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    private Vector3 startPosition;
    private int score;

    [SerializeField] 
    private PhysicsMovement physicsMovement;

    [SerializeField]
    private Transform projectileStart;

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private GameObject projectileObject;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void Shoot()
    {
        Projectile projectile = Instantiate(projectileObject, projectileStart.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.transform.eulerAngles = transform.rotation.eulerAngles;
        projectile.SetGunner(this);
    }

    public void Restart()
    {
        physicsMovement.enabled = false;
        transform.position = startPosition;
        physicsMovement.enabled = true;
    }

    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
