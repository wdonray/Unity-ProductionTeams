using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbaParticleBehaviour : MonoBehaviour
{
    public GameObject particlePrefab;
    
    public void FootDown()
    {
        var pos = transform.position;
        pos.Set(pos.x, 0, pos.z);
        var dust = Instantiate(particlePrefab, pos, Quaternion.identity);
        Destroy(dust, 1.5f);
    }
}
