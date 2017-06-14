using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : ScriptableObject, IDamageable
{
    public int Health = 500;
    public void TakeDamage(int amount)
    {
        if (Health <= 0)
        {
            Debug.Log("HE DEAD");
        }
        else
            Health -= amount;
        //Debug.Log("health is " + Health);
    }
}

public interface IDamager
{
    void DoDamage(IDamageable defender);
}

public interface IDamageable
{
    void TakeDamage(int amount);
}
