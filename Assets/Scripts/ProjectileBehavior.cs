using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour, IDamager
{

    private int _attackPower = 5;
    public int AttackPower
    {
        get { return _attackPower; }
        set { _attackPower = value; }
    }

    public void DoDamage(IDamageable defender)
    {
        defender.TakeDamage(AttackPower);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DoDamage(GetComponent<MinionCop>());
        }
    }

    void Update()
    {
        this.transform.Rotate(360 * Time.deltaTime, 0, 0);
    }


}
