using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour, IDamager
{

    private int _attackPower = 10;
    public MinionCop minion;

    private void Start()
    {
        minion = GetComponent<MinionCop>();
    }

    public int AttackPower
    {
        get { return _attackPower; }
        set { _attackPower = value; }
    }

    public void DoDamage(IDamageable defender)
    {
        defender.TakeDamage(AttackPower);
    }

    public void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DoDamage(minion);
            DestroyImmediate(gameObject);
        }
    }

    void Update()
    {
        this.transform.Rotate(360 * Time.deltaTime, 0, 0);
    }


}
