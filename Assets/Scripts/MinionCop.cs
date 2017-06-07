using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCop : ScriptableObject, IDamager, IDamageable
{
    public int CopHealth, CopDamage;
    // Use this for initialization
    public void DoDamage(IDamageable defender)
    {
        defender.TakeDamage(CopDamage);
    }

    public void TakeDamage(int amount)
    {
        CopHealth -= amount;
    }
}
