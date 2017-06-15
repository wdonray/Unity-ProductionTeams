using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitByBottleBehaviour : MonoBehaviour
{
    public GameObject particlePrefab;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bottle"))
        {
            var pos = collision.collider.gameObject.transform.position;
            var bloodSplatter = Instantiate(particlePrefab, pos, Quaternion.identity);
            Destroy(bloodSplatter, .5f);
        }
    }
}
