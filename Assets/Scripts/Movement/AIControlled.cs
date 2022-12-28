using System.Collections;
using UnityEngine;

public class AIControlled : MovementBehaviour
{
    private void Start()
    {
        StartCoroutine(AI());
    }
    private IEnumerator AI()
    {
        while (true)
        {
            direction = transform.forward * Random.Range(-1, 1) * moveSpeed;
            rotation.y = Random.Range(-1, 1) * rotateSpeed;
            yield return new WaitForSeconds(3);
        }
    }
}
