using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCop : ScriptableObject, IDamager, IDamageable
{
    public int Health, Damage;
    // Use this for initialization
    public void DoDamage(IDamageable defender)
    {
        defender.TakeDamage(Damage);
    }

    public void TakeDamage(int amount)
    {
        if (Health <= 0)
            Destroy(this);
        else
            Health -= amount;
    }
}
